using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Repository.Interfaces.FilterAttributes;
using TopLearn.DAL.Context;

namespace TopLearn.Core.Repository.Services.FilterAttributes
{
    public class FilterAttributesService : IFilterAttributeService
    {
        private readonly TopLearnContext _context;

        public FilterAttributesService(TopLearnContext context)
        {
            _context = context;
        }

        public bool HasPermission(int permissionId, string userName)
        {

            var userid = _context.Users.FirstOrDefault(u => u.UserName == userName).UserId;

            var listUserRoles = _context.RoleUsers
                .Where(r => r.UserId == userid)
                .Select(r => r.RoleId).ToList();

            if (!listUserRoles.Any())
            {
                return false;
            }


            foreach (var roleId in listUserRoles)
            {
                var hasPermission =
                    _context.RolePermissions.Any(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);

                if (hasPermission)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
