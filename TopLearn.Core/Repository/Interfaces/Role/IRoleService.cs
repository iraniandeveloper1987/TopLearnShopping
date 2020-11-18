using System.Collections.Generic;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repository.Interfaces.Role
{
    public interface IRoleService : IBaseService<DAL.Entities.Role>
    {
        bool DeleteRoleByRoleID(int roleId);

        List<DAL.Entities.Role> GetDeleteRoles();
        int AddRole(DAL.Entities.Role role);

    }



}
