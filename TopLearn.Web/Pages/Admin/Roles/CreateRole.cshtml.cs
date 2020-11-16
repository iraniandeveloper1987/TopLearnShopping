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
    public class CreateRoleModel : PageModel
    {
        private IRoleService _roleService;

        public CreateRoleModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [BindProperty]
        public Role Role { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _roleService.Add(Role);
            _roleService.Save();
            return RedirectToPage("Index");
        }
    }
}
