using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Admin;
using TopLearn.Core.DTOs.Admin.User;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces.User;

namespace TopLearn.Web.Pages.Admin.User
{

    [CheckPermissionAttribute((int)PermissionEnum.UserManagement)]
    public class IndexModel : PageModel
    {

        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }


        public UsersForAdminViewModel AllUsers { get; set; }


        private int _stepsShow = 0;

        public void OnGet(int numberPage = 1, string countShow = null, string fullName = null, string userName = null, string email = null, string mobile = null)
        {

            int countShowInPage = (!string.IsNullOrEmpty(countShow)) ? int.Parse(countShow) : 5;

            ViewData["countShowInPage"] = countShowInPage;

            AllUsers = new UsersForAdminViewModel
            {
                NumberPage = numberPage,
                Users = _userService.GetUsersForAdmin(out _stepsShow, numberPage, countShowInPage, fullName, userName, email, mobile),
                StepsForShow = _stepsShow
            };

        }



    }
}
