using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Admin.User;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces.User;

namespace TopLearn.Web.Pages.Admin.Users
{
    [CheckPermission((int)PermissionEnum.ListDeletedUsers)]
    public class ListDeletedUsers : PageModel
    {
        private readonly IUserService _userService;

        public ListDeletedUsers(IUserService userService)
        {
            _userService = userService;
        }


        [BindProperty]
        public UsersForAdminViewModel AllDeletedUsers { get; set; }


        private int _stepsShow = 0;

        public void OnGet(int numberPage = 1, string countShow = null, string fullName = null, string userName = null, string email = null, string mobile = null)
        {

            int countShowInPage = (!string.IsNullOrEmpty(countShow)) ? int.Parse(countShow) : 5;

            ViewData["countShowInPage"] = countShowInPage;

            AllDeletedUsers = new UsersForAdminViewModel
            {
                NumberPage = numberPage,
                Users = _userService.GetDeletedUsersForAdmin(out _stepsShow, numberPage, countShowInPage, fullName, userName, email, mobile),
                StepsForShow = _stepsShow
            };

        }
    }
}
  