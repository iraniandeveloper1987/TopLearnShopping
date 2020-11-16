using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repository.Interfaces
{
    public interface IRoleService : IBaseService<Role>
    {
        bool DeleteRoleByRoleID(int roleId);

        List<Role> GetDeleteRoles();

    }

}
