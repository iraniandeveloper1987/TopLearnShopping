using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.Core.DTOs.AccountViewModels
{
    public class ActiveViewModel
    {
        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        public string ActiveCode { get; set; }
    }
}
