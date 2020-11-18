using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities.Permissions;

namespace TopLearn.Core.Repository.Interfaces.Permission
{
    public interface IRolePermissionService : IBaseService<RolePermission>
    {
        List<int> GetPermissionByRoleId(int roleId);

        bool DeletePermissionByRoleId(int roleId);
        
        bool AddPermissionToRole(int roleId, List<int> selectedPermissions);

        bool UpdatePermissionToRole(int roleId, List<int> selectedPermissions);

       

    }
}
