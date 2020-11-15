using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.DTOs.Wallet;
using TopLearn.Core.Enums;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repository.Services
{
    public class WalletService : BaseService<Wallet>, IWalletService
    {

        private readonly TopLearnContext _context;
        public WalletService(TopLearnContext context) : base(context)
        {
            _context = context;
        }

        public int AccountBalance(string username)
        {
            var userId = GetUserIdByUserName(username);

            var deposit = _context.Wallets.Where(w => w.UserId == userId
                                                      && w.WalletTypeId == (int)TransactionType.Deposit
                                                      && w.IsPay).Sum(w => w.Amount);


            var withdraw = _context.Wallets.Where(w => w.UserId == userId
                                                       && w.WalletTypeId == (int)TransactionType.Withdraw
                                                       && w.IsPay).Sum(w => w.Amount);


            return deposit - withdraw;

        }

        public int GetUserIdByUserName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username).UserId;
        }

        public Wallet GetWalletByWalletId(int walletId)
        {
            return _context.Wallets.FirstOrDefault(w => w.WalletId == walletId);
        }

        public User GetUserByWalletId(int walletId)
        {
            return _context.Wallets.FirstOrDefault(w => w.WalletId == walletId)?.User;
        }

        public int AddWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet.WalletId;
        }

        public List<WalletViewModel> GetAllWalletByUserName(string username)
        {
            var userId = GetUserIdByUserName(username);

            return _context.Wallets.Where(w => w.UserId == userId && w.IsPay).Select(w => new WalletViewModel()
            {
                Amount = w.Amount,
                WalletType = w.WalletTypeId,
                Description = w.Description,
                DateTime = DateTime.Now
            }).ToList();
        }

        public List<WalletViewModel> GetAllWalletsWithPaging(string userName, out int numberSteps, int currentPage = 1, int countShow = 5)
        {


            var userId = GetUserIdByUserName(userName);

            int skipCount = (currentPage - 1) * countShow;

            var listOfWallets = _context.Wallets.Where(w => w.IsPay && w.UserId == userId).Skip(skipCount).Take(countShow)
              .Select(w => new WalletViewModel()
              {
                  Amount = w.Amount,
                  WalletType = w.WalletTypeId,
                  DateTime = w.RegisterDate,
                  Description = w.Description
              }).ToList();

            var countAllWallets = _context.Wallets.Count(w => w.UserId == userId);

            var restOfDivision = countAllWallets % countShow;

            numberSteps = (restOfDivision != 0 ? (countAllWallets / countShow) + 1 : (countAllWallets / countShow));

            return listOfWallets;
        }

        public int ChargeWallet(string username, int amount)
        {
            var wallet = new Wallet()
            {
                Amount = amount,
                Description = "شارژ کیف پول",
                IsPay = false,
                RegisterDate = DateTime.Now,
                WalletTypeId = (int)TransactionType.Deposit,
                UserId = GetUserIdByUserName(username)

            };

            return AddWallet(wallet);
        }

    }

}
