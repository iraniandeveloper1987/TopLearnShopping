using System.Collections.Generic;
using TopLearn.Core.DTOs.Admin.User;
using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Services.Interfaces.Base;

namespace TopLearn.Core.Repository.Interfaces.User
{
    public interface IUserService : IBaseService<DAL.Entities.User>
    {

        #region User Account

        bool IsExistEmail(string email);
        bool IsExistMobile(string mobile);
        bool IsExistUserName(string username);
        bool IsExistActiveCode(string activecode);


        DAL.Entities.User GetUserByUserName(string username);

        DAL.Entities.User GetUserByEmail(string email);

        DAL.Entities.User GetUserByMobile(string mobile);

        DAL.Entities.User GetUserByActiveCode(string activeCode);

        DAL.Entities.User LoginByMobile(string mobile, string password);

        DAL.Entities.User LoginByEmail(string email, string password);

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

        List<DAL.Entities.User> GetUsersForAdmin(out int numberSteps, int pageNUmber = 1, int countShow = 5, string filterFullName = null, string filterUserName = null, string filterEmail = null, string filterMobile = null);

        List<DAL.Entities.User> GetDeletedUsersForAdmin(out int numberSteps, int pageNUmber = 1, int countShow = 5, string filterFullName = null, string filterUserName = null, string filterEmail = null, string filterMobile = null);

        int CreateUserFromAdmin(CreateUserViewModel userModel);

        int AddUser(DAL.Entities.User user);

        bool EdithUserFromAdmin(EditUserViewModel user);

        DAL.Entities.User GetUserByUserId(int userId);

        EditUserViewModel GetUserInAdminEditModeByUserId(int userId);

        bool DeleteUser(int userId);

        UserInfoesViewModel GetUserInDeleteModeInAdmin(int userId);

        #endregion



    }
}
