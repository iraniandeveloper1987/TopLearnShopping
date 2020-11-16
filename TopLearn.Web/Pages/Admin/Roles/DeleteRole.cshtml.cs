using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.DAL.Entities;

namespace TopLearn.Web.Pages.Admin.Roles
{
    public class DeleteRoleModel : PageModel
    {
        private IRoleService _roleService;

        public DeleteRoleModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int roleId)
        {
            Role = _roleService.GetById(roleId);
        }

        public IActionResult OnPost()
        {
            _roleService.DeleteRoleByRoleID(Role.RoleId);

            return RedirectToPage("Index");
        }
    }
}
