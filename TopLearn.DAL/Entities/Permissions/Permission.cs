using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DAL.Entities.Permissions
{
    public class Permission
    {
        public Permission()
        {
            RolePermissions = new List<RolePermission>();
        }

        [Key]
        public int PermissionId { get; set; }

        [Display(Name = "عنوان دسترسی")]
        [MaxLength(100, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        public string PermissionTitle { get; set; }

        public int? ParentId { get; set; }

        public bool IsDeleted { get; set; }


        #region Navigation Properties

        [ForeignKey("ParentId")]
        public virtual List<Permission> Permissions { get; set; }

        public virtual List<RolePermission> RolePermissions { get; set; }

        #endregion
    }
}
