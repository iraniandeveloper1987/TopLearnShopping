using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopLearn.Core.DTOs.AccountViewModels;
using TopLearn.DAL.Entities;

namespace TopLearn.WebApi.Repository.Contracts
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> Login(LoginEmailViewModel loginEmailViewModel);
        ICollection<User> GetAllUsers();
        Task<User> FindUser(int userId);
      

    }
}
