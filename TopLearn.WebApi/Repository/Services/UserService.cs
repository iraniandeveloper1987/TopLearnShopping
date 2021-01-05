using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.DTOs.AccountViewModels;
using TopLearn.Core.Security;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities;
using TopLearn.WebApi.Repository.Contracts;

namespace TopLearn.WebApi.Repository.Services
{
    public class UserService : IUserService
    {
        private readonly TopLearnContext _context;

        public UserService(TopLearnContext context)
        {
            _context = context;
        }

        public async Task<User> FindUser(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> Login(LoginEmailViewModel loginEmailViewModel)
        {
            return await _context.Users.Include(u => u.RoleUsers).ThenInclude(ru => ru.Role).FirstOrDefaultAsync(u => u.Email == loginEmailViewModel.Email &&

                                                                         u.Password == PasswordHelper.EncodePasswordMd5(loginEmailViewModel.Password));
        }

        public ICollection<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
