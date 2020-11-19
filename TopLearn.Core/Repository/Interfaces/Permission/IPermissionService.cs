using System.Collections.Generic;
using TopLearn.Core.Services.Interfaces.Base;

namespace TopLearn.Core.Repository.Interfaces.Permission
{
    public interface IPermissionService : IBaseService<DAL.Entities.Permissions.Permission>
    {
        bool AddPermission(string permissionName, int parentId);

        bool EditPermission(int permissionId, string permissionName);

        bool DeletePermissions(List<int> selectedPermissionId);
    }
}
