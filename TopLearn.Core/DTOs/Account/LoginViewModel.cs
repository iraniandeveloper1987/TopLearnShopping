using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.AccountViewModels
{
    public class LoginEmailViewModel
    {

        [Display(Name = "پست الکترونیکی")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "پست الکترونیکی وارد شده نا معتبر می باشد")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرابخاطر بسپار")]
        public bool RememberMe { get; set; }
       
    }

    public class LoginMobileViewModel
    {
        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Mobile { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرابخاطر بسپار")]
        public bool RememberMe { get; set; }

    }
}
