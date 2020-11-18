using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Repository.Interfaces.Permission;
using TopLearn.Core.Repository.Interfaces.Role;
using TopLearn.DAL.Entities;
using TopLearn.DAL.Entities.Permissions;

namespace TopLearn.Web.Pages.Admin.Roles
{
    public class CreateRoleModel : PageModel
    {
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permission;
        private readonly IRolePermissionService _rolePermissionService;

        public CreateRoleModel(IRoleService roleService, IPermissionService permission, IRolePermissionService rolePermissionService)
        {
            _roleService = roleService;
            _permission = permission;
            _rolePermissionService = rolePermissionService;
        }

        [BindProperty]
        public Role Role { get; set; }

        public void OnGet()
        {
            ViewData["Permissions"] = _permission.Get();
        }

        public IActionResult OnPost(List<int> selectedPermission)
        {

           var roleId= _roleService.AddRole(Role);
           


            if (selectedPermission.Count>0)
            {
             
                _rolePermissionService.AddPermissionToRole(Role.RoleId, selectedPermission);

                _rolePermissionService.Save();
            }
         

            return RedirectToPage("Index");
        }
    }
}
