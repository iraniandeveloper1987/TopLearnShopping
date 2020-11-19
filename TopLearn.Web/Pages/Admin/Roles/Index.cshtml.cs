using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Repository.Interfaces.Role;
using TopLearn.DAL.Entities;

namespace TopLearn.Web.Pages.Admin.Roles
{

    [CheckPermission((int)PermissionEnum.RoleManagement)]
    public class IndexModel : PageModel
    {
        private  readonly IRoleService _roleService;

        public IndexModel(IRoleService roleService)
        {
            _roleService = roleService;
        }
        
        [BindProperty]
        public IEnumerable<Role> Roles { get; set; }


        public void OnGet()
        {
            Roles = _roleService.Get();
        }



    }
}
