using System.ComponentModel.DataAnnotations;

namespace TopLearn.Core.DTOs.AccountViewModels
{
    public class RegisterViewModel
    {

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string FullName { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string UserName { get; set; }

        [Display(Name = "پست الکترونیکی")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "پست الکترونیکی وارد شده نا معتبر می باشد")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Email { get; set; }

        [Display(Name = "تلفن همراه")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Mobile { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "تایید کلمه عبور")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [Compare("Password", ErrorMessage = "کلمات عبور وارد شده یکسان نیست")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}
