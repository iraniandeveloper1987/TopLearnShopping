using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.DAL.Entities
{
    public class User
    {

        public User()
        {
            RoleUsers = new List<RoleUser>();
            Wallets = new List<Wallet>();
        }

        [Key]
        public int UserId { get; set; }

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
        public string Password { get; set; }


        [Display(Name = "کد فعال سازی")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        public string ActiveCode { get; set; }


        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }


        [Display(Name = "آواتار ")]
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string UserAvatar { get; set; }


        [Display(Name = "تاریخ ثیت نام")]
        public DateTime RegisterDate { get; set; }

        public bool IsDeleted { get; set; }

        
        #region Navigation Properties

        public virtual List<RoleUser> RoleUsers { get; set; }

        public virtual List<Wallet> Wallets { get; set; }

        public virtual List<Course.Course> Courses { get; set; }

      
        #endregion

    }
}
