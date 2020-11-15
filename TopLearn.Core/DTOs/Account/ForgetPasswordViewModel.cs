using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.Core.DTOs.Account
{
    public class ForgetPasswordByEmailViewModel
    {
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "پست الکترونیکی وارد شده نا معتبر می باشد")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        public string Email { get; set; }

    }


    public class ForgetPasswordByMobileViewModel
    {
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Mobile { get; set; }

    }
}
