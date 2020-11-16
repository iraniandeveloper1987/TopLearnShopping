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
    public class ListDeletedRolesModel : PageModel
    {
        private readonly IRoleService _roleService;

        public ListDeletedRolesModel(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public List<Role> DeleteRoles { get; set; }

        public void OnGet()
        {
            DeleteRoles = _roleService.GetDeleteRoles();
        }
    }
}
