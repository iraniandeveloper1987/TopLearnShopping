using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Admin.User;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Repository.Interfaces.Role;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.DAL.Entities;

namespace TopLearn.Web.Pages.Admin.Users
{
    [CheckPermission((int)PermissionEnum.EditUser)]
    public class EditUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleUserService _roleUserService;
        private readonly IRoleService _roleService;

        public EditUserModel(IUserService userService, IRoleUserService roleUserService, IRoleService roleService)
        {
            _userService = userService;
            _roleUserService = roleUserService;
            _roleService = roleService;
        }

        [BindProperty]
        public EditUserViewModel EditUser { get; set; }

        public void OnGet(int userId)
        {

            EditUser = _userService.GetUserInAdminEditModeByUserId(userId);

            ViewData["Roles"] = _roleService.Get();

            //ViewData["SelectedRolesId"] = _roleUserService.GetRolesIdByUserId(userId);

        }


        public IActionResult OnPost(List<int> SelectedRolesId)
        {



            var editResult = _userService.EdithUserFromAdmin(EditUser);


            if (editResult)
            {
                _userService.Save();

                var roleuserresult = _roleUserService.RemoveAllRoleUsersByUserId(EditUser.UserId);

                if (roleuserresult)
                {

                    foreach (int roleId in SelectedRolesId)
                    {
                        _roleUserService.Add(new RoleUser()
                        {
                            UserId = EditUser.UserId,
                            RoleId = roleId
                        });
                    }
                }

            }


            _roleUserService.Save();

            ViewData["Roles"] = _roleService.Get();
            EditUser.SelectedRolesId = SelectedRolesId;
            ViewData["IsSuccess"] = true;

            return RedirectToPage("Index");
        }
    }
}
