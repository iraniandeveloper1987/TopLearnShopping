using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.DTOs.Wallet;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repository.Interfaces
{
    public interface IWalletService : IBaseService<Wallet>
    {

        int AccountBalance(string username);

        int GetUserIdByUserName(string username);

        Wallet GetWalletByWalletId(int walletId);

        User GetUserByWalletId(int walletId);

        int AddWallet(Wallet wallet);

        List<WalletViewModel> GetAllWalletByUserName(string username);

        List<WalletViewModel> GetAllWalletsWithPaging(string userName, out int numberSteps, int currentPage = 1, int countShow = 5);

        int ChargeWallet(string username, int amount);
    }


}
