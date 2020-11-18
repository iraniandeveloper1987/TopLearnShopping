using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Repository.Interfaces.Permission;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Permissions;

namespace TopLearn.Core.Repository.Services.Permission
{
    public class RolePermissionService : BaseService<RolePermission>, IRolePermissionService
    {
        private TopLearnContext _context;
        public RolePermissionService(TopLearnContext context) : base(context)
        {
            _context = context;
        }

        public List<int> GetPermissionByRoleId(int roleId)
        {

            return _context.RolePermissions
                .Where(rp => rp.RoleId == roleId)
                .Select(rp => rp.PermissionId).ToList();
        }

        public bool DeletePermissionByRoleId(int roleId)
        {
            _context.RolePermissions
               .Where(rp => rp.RoleId == roleId).ToList().ForEach(a => Delete(a));
            base.Save();
            return true;

        }

        public bool AddPermissionToRole(int roleId, List<int> selectedPermissions)
        {

           selectedPermissions.ForEach(sp => Add(new RolePermission()
           {
               RoleId = roleId ,
               PermissionId = sp
           }));

            return true;
        }

        public bool UpdatePermissionToRole(int roleId, List<int> selectedPermissions)
        {
            DeletePermissionByRoleId(roleId);
            AddPermissionToRole(roleId, selectedPermissions);
            return true;
        }
    }
}
