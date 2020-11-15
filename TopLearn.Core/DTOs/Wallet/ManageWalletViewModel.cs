using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.DTOs.Wallet
{
    public class ManageWalletViewModel
    {
        public ChargeWalletViewModel ChargeWallet { get; set; }

        public List<WalletViewModel> wallets { get; set; }

        public int AccountBalance { get; set; }
    }
}
