using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Repository.Interfaces.Permission;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;

namespace TopLearn.Core.Repository.Services.Permission
{
    public class PermissionService : BaseService<DAL.Entities.Permissions.Permission>, IPermissionService
    {
        private TopLearnContext _context;
        public PermissionService(TopLearnContext context) : base(context)
        {
            _context = context;
        }

        public bool AddPermission(string permissionName, int parentId)
        {
            base.Add(new DAL.Entities.Permissions.Permission()
            {
                PermissionTitle = permissionName,
                ParentId = parentId
            });

            base.Save();

            return true;
        }

        public bool EditPermission(int permissionId, string permissionName)
        {
            var permission = base.GetById(permissionId);
            permission.PermissionTitle = permissionName;
            base.Update(permission);
            return true;
        }

        public bool DeletePermissions(List<int> selectedPermissionId)
        {

            foreach (var permissionId in selectedPermissionId)
            {
                var existRolePermission = _context.RolePermissions.FirstOrDefault(rp => rp.PermissionId == permissionId);

                if (existRolePermission != null)
                {
                    _context.RolePermissions.Remove(existRolePermission);
                    _context.SaveChanges();
                }


                var permission = _context.Permissions.FirstOrDefault(p => p.PermissionId == permissionId);

                _context.Permissions.Remove(permission);
                
            }

            _context.SaveChanges();

            return true;
        }
    }
}
