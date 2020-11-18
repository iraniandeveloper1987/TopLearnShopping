using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TopLearn.DAL.Entities.Permissions;

namespace TopLearn.DAL.Entities
{
    public class Role
    {
        public Role()
        {
            RoleUsers = new List<RoleUser>();
            RolePermissions = new List<RolePermission>();
        }

        [Key]
        public int RoleId { get; set; }

        [Display(Name = "نام نقش به لاتین ")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string RoleName { get; set; }

        [Display(Name = "نام نقش ")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        #region Navigation Properties

        public virtual List<RoleUser> RoleUsers { get; set; }

        public virtual List<RolePermission> RolePermissions { get; set; }

        #endregion
    }
}
