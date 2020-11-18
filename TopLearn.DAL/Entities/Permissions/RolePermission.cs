using System;
using System.Collections.Generic;
using System.Text;

namespace TopLearn.DAL.Entities.Permissions
{
    public class RolePermission
    {
        public RolePermission()
        {

        }
        public int RolePermissionId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }


        #region Navigation Properties

        public virtual Role Role { get; set; }

        public virtual Permission Permission { get; set; }

        #endregion

    }


}
