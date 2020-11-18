using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Repository.Interfaces;
using TopLearn.Core.Repository.Interfaces.Role;
using TopLearn.DAL.Entities;

namespace TopLearn.Web.Pages.Admin.Roles
{
    public class IndexModel : PageModel
    {
        private IRoleService _roleService;

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
