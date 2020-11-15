using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repository.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {


        public RoleService(TopLearnContext context) : base(context)
        {

        }
    }
}
