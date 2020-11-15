using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.DTOs.Admin.User
{
    public class EditUserViewModel
    {

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
       [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Password { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }


        [Display(Name = "آواتار")]
        public IFormFile UserAvatar { get; set; }


        [Display(Name = "نام آواتار")]
        public string UserAvatarName { get; set; }


        public List<int> SelectedRolesId { get; set; }


        public IEnumerable<int> RolesId { get; set; }



    }
}
