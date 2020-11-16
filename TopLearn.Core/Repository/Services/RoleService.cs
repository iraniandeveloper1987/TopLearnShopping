using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repository.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {

        private TopLearnContext _context;

        public RoleService(TopLearnContext context) : base(context)
        {
            _context = context;
        }

        public bool DeleteRoleByRoleID(int roleId)
        {
            var role = base.GetById(roleId);
            role.IsDeleted = true;
            base.Save();
            return true;
        }

        public List<Role> GetDeleteRoles()
        {
            return _context.Roles.IgnoreQueryFilters().Where(r => r.IsDeleted).ToList();
        }
    }
}
