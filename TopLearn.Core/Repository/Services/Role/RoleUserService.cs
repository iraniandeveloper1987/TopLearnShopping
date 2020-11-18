using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Repository.Interfaces.Role;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Services
{
    public class RoleUserService : BaseService<RoleUser>, IRoleUserService
    {
        private readonly TopLearnContext _context;

        public RoleUserService(TopLearnContext context) : base(context)
        {
            _context = context;
        }


        public List<int> GetRolesIdByUserId(int userId)
        {
            return _context.RoleUsers.Where(ru => ru.UserId == userId).Select(ru => ru.RoleId).ToList();
        }

        public bool RemoveAllRoleUsersByUserId(int userId)
        {
            _context.RoleUsers.Where(ru => ru.UserId == userId).ToList().ForEach(roleuser => base.Delete(roleuser));
            _context.SaveChanges();

            return true;
        }
    }

}
