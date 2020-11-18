using System.Collections.Generic;
using TopLearn.Core.DTOs.Wallet;
using TopLearn.Core.Services.Interfaces.Base;

namespace TopLearn.Core.Repository.Interfaces.Wallet
{
    public interface IWalletService : IBaseService<DAL.Entities.Wallet>
    {

        int AccountBalance(string username);

        int GetUserIdByUserName(string username);

        DAL.Entities.Wallet GetWalletByWalletId(int walletId);

        DAL.Entities.User GetUserByWalletId(int walletId);

        int AddWallet(DAL.Entities.Wallet wallet);

        List<WalletViewModel> GetAllWalletByUserName(string username);

        List<WalletViewModel> GetAllWalletsWithPaging(string userName, out int numberSteps, int currentPage = 1, int countShow = 5);

        int ChargeWallet(string username, int amount);
    }


}
