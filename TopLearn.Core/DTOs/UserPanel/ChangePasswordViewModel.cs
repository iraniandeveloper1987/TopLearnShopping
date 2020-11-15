using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace TopLearn.Core.DTOs.UserPanel
{
    public class ChangePasswordViewModel
    {

        [Display(Name = " کلمه عبور فعلی")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [DataType(DataType.Password)]
        [Remote("IsExistCurrentPassword", "RemoteValidations", "UserPanel")]
        public string CurrentPassword { get; set; }


        [Display(Name = "کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }


        [Display(Name = "تایید کلمه عبور جدید")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [Compare("NewPassword", ErrorMessage = "کلمات عبور وارد شده یکسان نیست")]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}
