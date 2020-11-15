using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.Core.DTOs.Wallet
{
    public class ChargeWalletViewModel
    {
        [Display(Name = "مبلغ شارژ")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        public int Amount { get; set; }
    }
}
