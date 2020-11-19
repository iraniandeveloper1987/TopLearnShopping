using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces.User;

namespace TopLearn.Web.Pages.Admin.Users
{
    [CheckPermission((int)PermissionEnum.DeleteUser)]
    public class DeleteUserModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserInfoesViewModel UserViewModels { get; set; }

        public void OnGet(int userId)
        {
            UserViewModels = _userService.GetUserInDeleteModeInAdmin(userId);
        }

        public IActionResult OnPost(int userId)
        {
            _userService.DeleteUser(userId);
            _userService.Save();

            return RedirectToPage("Index");
        }
    }
}
