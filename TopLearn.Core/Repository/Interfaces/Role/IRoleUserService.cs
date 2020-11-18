using System.Collections.Generic;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repository.Interfaces.Role
{
    public interface IRoleUserService : IBaseService<RoleUser>
    {

        List<int> GetRolesIdByUserId(int userId);

        bool RemoveAllRoleUsersByUserId(int userId);



    }
}
