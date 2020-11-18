using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Admin;
using TopLearn.Core.DTOs.Admin.User;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Repository.Interfaces.Role;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.DAL.Entities;

namespace TopLearn.Web.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleUserService _roleUserService;
        private readonly IRoleService _roleService;

        public CreateUserModel(IUserService userService, IRoleUserService roleUserService, IRoleService roleService)
        {
            _userService = userService;
            _roleUserService = roleUserService;
            _roleService = roleService;
        }


        [BindProperty]
        public CreateUserViewModel CreateUser { get; set; }


        public void OnGet()
        {

            ViewData["Roles"] = _roleService.Get();


        }




        public IActionResult OnPost(List<int> SelectedRoleIds)
        {


            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = _roleService.Get();
                return Page();
            }
            int userId = _userService.CreateUserFromAdmin(CreateUser);

            foreach (int RoleId in SelectedRoleIds)
            {
                _roleUserService.Add(new RoleUser()
                {
                    UserId = userId,
                    RoleId = RoleId
                });
            }
            _roleUserService.Save();


            ViewData["IsSuccess"] = true;
            ViewData["Roles"] = _roleService.Get();
            return Page();
        }
    }
}
