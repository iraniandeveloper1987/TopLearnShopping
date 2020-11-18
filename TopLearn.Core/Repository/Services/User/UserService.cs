using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TopLearn.Core.Code_Generator;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs.Admin;
using TopLearn.Core.DTOs.Admin.User;
using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.Core.Repository.Interfaces.Wallet;
using TopLearn.Core.Security;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IWalletService _walletService;
        private readonly TopLearnContext _context;

        public UserService(TopLearnContext context, IWalletService walletService) : base(context)
        {
            _context = context;
            _walletService = walletService;
        }

        public bool ActiveUser(string activecode)
        {
            var user = _context.Users.FirstOrDefault(u => u.ActiveCode == activecode && !u.IsActive);

            if (user == null) return false;

            user.IsActive = true;
            user.ActiveCode = ActiveCode.Generate();
            _context.Users.Update(user);
            _context.SaveChanges();
            return true;

        }


        #region User Account

        public User LoginByMobile(string mobile, string password)
        {
            return _context.Users.FirstOrDefault(u =>
                u.Mobile == mobile && password == u.Password);
        }

        public User LoginByEmail(string email, string password)
        {
            return _context.Users.FirstOrDefault(u =>
                u.IsActive && u.Mobile == email && password == u.Password);
        }



        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistMobile(string mobile)
        {
            return _context.Users.Any(u => u.Mobile == mobile);
        }

        public bool IsExistUserName(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }


        public bool IsExistActiveCode(string activecode)
        {
            return _context.Users.Any(u => u.ActiveCode == activecode);
        }

        public User GetUserByUserName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public User GetUserByMobile(string mobile)
        {
            return _context.Users.FirstOrDefault(u => u.Mobile == mobile);
        }


        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.FirstOrDefault(u => u.ActiveCode == activeCode);
        }


        public int GetUserIdByUserName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username).UserId;
        }

        #endregion

        #region User Panel

        public UserInfoesViewModel GetUserInfoes(string username)
        {
            return _context.Users.Where(u => u.UserName == username).Select(u => new UserInfoesViewModel()
            {
                UserName = u.UserName,
                FullName = u.FullName,
                Mobile = u.Mobile,
                Email = u.Email,
                RegisterDateTime = u.RegisterDate,
                WalletBalance = _walletService.AccountBalance(username)

            }).FirstOrDefault();
        }

        public SideBarUserPanelViewModel GetSideBarUserPanelInfoes(string username)
        {
            return _context.Users.Where(u => u.UserName == username).Select(u => new SideBarUserPanelViewModel()
            {
                FullName = u.FullName,
                RegisterDate = u.RegisterDate,
                ImageName = u.UserAvatar
            }).FirstOrDefault();
        }

        public EditProfileViewModel GetEditProfile(string username)
        {
            return _context.Users.Where(u => u.UserName == username).Select(u => new EditProfileViewModel()
            {
                FullName = u.FullName,
                UserName = u.UserName,
                Mobile = u.Mobile,
                Email = u.Email,
                UserAvatar = u.UserAvatar
            })
                .FirstOrDefault();
        }

        public void EditProfile(string curentUserName, EditProfileViewModel model)
        {
            try
            {

                #region Manage Image File


                // Have User Avatar Image

                if (model.Avatar != null)
                {

                    var imagePath = string.Empty;



                    // Remove Image  except Default Image

                    if (model.UserAvatar != "Default.jpg")
                    {

                        imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Users/UserAvatar",
                            model.UserAvatar);


                        if (File.Exists(imagePath))
                        {
                            File.Delete(imagePath);
                        }
                    }




                    #region Save Upload 's Image 

                    model.UserAvatar = NameGenerator.Generate() + Path.GetExtension(model.UserAvatar);

                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Users/UserAvatar",
                        model.UserAvatar);


                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        model.Avatar.CopyTo(stream);
                    }


                    #endregion

                }

                #endregion



                // Update User (Profile)

                var user = GetUserByUserName(curentUserName);

                user.FullName = model.FullName;
                user.UserName = model.UserName;
                user.UserAvatar = model.UserAvatar;
                user.Email = model.Email.EmailFixed();
                user.Mobile = model.Mobile;
                user.UserAvatar = model.UserAvatar;
                _context.Users.Update(user);
                _context.SaveChanges();



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool IsExistCurrentPassword(string currentPassword)
        {
            return _context.Users.Any(u => u.Password == currentPassword);
        }


        #endregion


        #region Admin

        public List<User> GetUsersForAdmin(out int numberSteps, int pageNUmber = 1, int countShow = 5, string filterFullName = null, string filterUserName = null, string filterEmail = null, string filterMobile = null)
        {

            var take = countShow;

            var skip = (pageNUmber - 1) * take;

            var countAllUsers = _context.Users.Count();

            var restOfDivision = countAllUsers % take;

            numberSteps = (restOfDivision != 0 ? (countAllUsers / take) + 1 : (countAllUsers / countShow));


            IQueryable<User> Users = _context.Users;

            if (!string.IsNullOrEmpty(filterFullName))
            {
                Users = Users.Where(u => u.FullName.Contains(filterFullName));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                Users = Users.Where(u => u.UserName.Contains(filterUserName));
            }

            if (!string.IsNullOrEmpty(filterEmail))
            {
                Users = Users.Where(u => u.Email.Contains(filterEmail.EmailFixed()));
            }

            if (!string.IsNullOrEmpty(filterMobile))
            {
                Users = Users.Where(u => u.Mobile.Contains(filterMobile));
            }

            return Users.OrderByDescending(u => u.RegisterDate).Skip(skip).Take(take).ToList();
        }

        public List<User> GetDeletedUsersForAdmin(out int numberSteps, int pageNUmber = 1, int countShow = 5, string filterFullName = null,
            string filterUserName = null, string filterEmail = null, string filterMobile = null)
        {
            var take = countShow;

            var skip = (pageNUmber - 1) * take;

            var countAllUsers = _context.Users.Count();

            var restOfDivision = countAllUsers % take;

            numberSteps = (restOfDivision != 0 ? (countAllUsers / take) + 1 : (countAllUsers / countShow));


            IQueryable<User> Users = _context.Users.IgnoreQueryFilters().Where(u => u.IsDeleted);

            if (!string.IsNullOrEmpty(filterFullName))
            {
                Users = Users.Where(u => u.FullName.Contains(filterFullName));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                Users = Users.Where(u => u.UserName.Contains(filterUserName));
            }

            if (!string.IsNullOrEmpty(filterEmail))
            {
                Users = Users.Where(u => u.Email.Contains(filterEmail.EmailFixed()));
            }

            if (!string.IsNullOrEmpty(filterMobile))
            {
                Users = Users.Where(u => u.Mobile.Contains(filterMobile));
            }

            return Users.OrderByDescending(u => u.RegisterDate).Skip(skip).Take(take).ToList();
        }

        public int CreateUserFromAdmin(CreateUserViewModel userModel)
        {
            var user = new User()
            {
                FullName = userModel.FullName,
                UserName = userModel.UserName,
                Email = userModel.Email.EmailFixed(),
                Mobile = userModel.Mobile,
                Password = PasswordHelper.EncodePasswordMd5(userModel.Password),
                ActiveCode = ActiveCode.Generate(),
                IsActive = true,
                RegisterDate = DateTime.Now,
                UserAvatar = "Default.jpg"

            };

            #region Save Upload 's Image 

            if (userModel.UserAvatar != null)
            {
                user.UserAvatar = NameGenerator.Generate() + Path.GetExtension(userModel.UserAvatar.FileName);

                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Users/UserAvatar",
                    user.UserAvatar);


                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    userModel.UserAvatar.CopyTo(stream);
                }



            }

            #endregion


            return AddUser(user);
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public bool EdithUserFromAdmin(EditUserViewModel user)
        {


            var userModel = GetUserByUserId(user.UserId);

            userModel.FullName = user.FullName;
            userModel.UserName = user.UserName;
            userModel.Email = user.Email.EmailFixed();
            userModel.Mobile = user.Mobile;

            if (!string.IsNullOrEmpty(user.Password))
            {
                userModel.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            }

            userModel.IsActive = user.IsActive;


            #region Manage Image File


            // Have User Avatar Image

            if (user.UserAvatar != null)
            {

                var imagePath = string.Empty;


                // Remove Image  except Default Image

                if (user.UserAvatar.Name != "Default.jpg")
                {

                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Users/UserAvatar",
                        user.UserAvatarName);


                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }




                #region Save Upload 's Image 

                userModel.UserAvatar = NameGenerator.Generate() + Path.GetExtension(user.UserAvatar.FileName);

                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Users/UserAvatar",
                    userModel.UserAvatar);


                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }


                #endregion

            }

            #endregion




            Update(userModel);
            Save();

            return true;

        }

        public EditUserViewModel GetUserInAdminEditModeByUserId(int userId)
        {
            var user = _context.Users.Where(u => u.UserId == userId).Select(u => new EditUserViewModel()
            {
                UserId = u.UserId,
                FullName = u.FullName,
                UserName = u.UserName,
                Email = u.Email,
                Mobile = u.Mobile,
                IsActive = u.IsActive,
                UserAvatarName = u.UserAvatar
                //SelectedRolesId = u.RoleUsers.Select(ru=> ru.UserId).ToList()
            }).FirstOrDefault();

            user.SelectedRolesId = _context.RoleUsers.Where(ru => ru.UserId == userId).Select(r => r.RoleId).ToList();

            return user;
        }

        public bool DeleteUser(int userId)
        {

            var user = _context.Users.Find(userId);
            user.IsDeleted = true;
            return true;
        }

        public UserInfoesViewModel GetUserInDeleteModeInAdmin(int userId)
        {
            var user = _context.Users.Where(u => u.UserId == userId).Select(u => new UserInfoesViewModel()
            {
                UserName = u.UserName,
                FullName = u.FullName,
                Email = u.Email,
                Mobile = u.Mobile,
                RegisterDateTime = u.RegisterDate,

            })
                .FirstOrDefault();

            user.WalletBalance = _walletService.AccountBalance(user.UserName);
            return user;
        }

        public User GetUserByUserId(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }



        #endregion

    }

}

