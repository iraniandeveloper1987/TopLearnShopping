using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.Core.DTOs.Wallet
{
    public class WalletViewModel
    {

        [Display(Name = "مبلغ")]
        public int Amount { get; set; }

        [Display(Name = "نوع تراکنش")]
        public int WalletType { get; set; }

        [Display(Name = "شرح")]
        public string Description { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public DateTime DateTime { get; set; }


    }
}
