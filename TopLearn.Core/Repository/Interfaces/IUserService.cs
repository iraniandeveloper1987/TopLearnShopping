using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.DTOs.Account;
using TopLearn.Core.DTOs.Admin;
using TopLearn.Core.DTOs.Admin.User;
using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities;

namespace TopLearn.Core.Repositories
{
    public interface IUserService : IBaseService<User>
    {

        #region User Account

        bool IsExistEmail(string email);
        bool IsExistMobile(string mobile);
        bool IsExistUserName(string username);
        bool IsExistActiveCode(string activecode);


        User GetUserByUserName(string username);

        User GetUserByEmail(string email);

        User GetUserByMobile(string mobile);

        User GetUserByActiveCode(string activeCode);

        User LoginByMobile(string mobile, string password);

        User LoginByEmail(string email, string password);

        int GetUserIdByUserName(string username);
        #endregion

        #region UserPanel

        UserInfoesViewModel GetUserInfoes(string username);

        SideBarUserPanelViewModel GetSideBarUserPanelInfoes(string username);

        EditProfileViewModel GetEditProfile(string username);

        void EditProfile(string curentUserName, EditProfileViewModel model);

        bool IsExistCurrentPassword(string currentPassword);

        #endregion

        #region Admin

        List<User> GetUsersForAdmin(out int numberSteps, int pageNUmber = 1, int countShow = 5, string filterFullName = null, string filterUserName = null, string filterEmail = null, string filterMobile = null);

        List<User> GetDeletedUsersForAdmin(out int numberSteps, int pageNUmber = 1, int countShow = 5, string filterFullName = null, string filterUserName = null, string filterEmail = null, string filterMobile = null);

        int CreateUserFromAdmin(CreateUserViewModel userModel);

        int AddUser(User user);

        bool EdithUserFromAdmin(EditUserViewModel user);

        User GetUserByUserId(int userId);

        EditUserViewModel GetUserInAdminEditModeByUserId(int userId);

        #endregion



    }
}
