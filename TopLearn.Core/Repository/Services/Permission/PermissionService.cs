using System;
using System.Collections.Generic;
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
    }
}
