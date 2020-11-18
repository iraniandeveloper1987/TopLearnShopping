using System;
using System.Collections.Generic;
using System.Linq;
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

    public class EditRoleModel : PageModel
    {
        private readonly IRoleService _roleService;
        private readonly IPermissionService _permissionService;
        private readonly IRolePermissionService _rolePermissionService;

        public EditRoleModel(IRoleService roleService, IRolePermissionService rolePermissionService, IPermissionService permissionService)
        {
            _roleService = roleService;
            _rolePermissionService = rolePermissionService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }


        public void OnGet(int roleId)
        {
            Role = _roleService.GetById(roleId);
            ViewData["selectedPermissions"] = _rolePermissionService.GetPermissionByRoleId(roleId);
            ViewData["permissions"] = _permissionService.Get();
        }


        public IActionResult OnPost(List<int> selectedPermissions)
        {
            _roleService.Update(Role);
            _roleService.Save();

            _rolePermissionService.UpdatePermissionToRole(Role.RoleId, selectedPermissions);
            _rolePermissionService.Save();

            return RedirectToPage("Index");

        }
    }
}
