using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces.Permission;
using TopLearn.DAL.Entities.Permissions;

namespace TopLearn.Web.Pages.Admin.Permissions
{

    [CheckPermission((int)PermissionEnum.EditPermission)]
    public class EditPermissionModel : PageModel
    {
        private readonly IPermissionService _permissionService;

        public EditPermissionModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Permission Permission { get; set; }

        public void OnGet()
        {
            ViewData["Permission"] = _permissionService.Get();
        }

        public IActionResult OnPost(List<int> selectedPermission)
        {

            if (!selectedPermission.Any())
            {
                ViewData["NotSelectPermission"] = true;
                ViewData["Permission"] = _permissionService.Get();
                return Page();
            }

            if (selectedPermission.Count > 1)
            {
                ViewData["OverSelectPemission"] = true;
                ViewData["Permission"] = _permissionService.Get();
                return Page();
            }


            _permissionService.EditPermission(selectedPermission.FirstOrDefault(), Permission.PermissionTitle);
            _permissionService.Save();


            ViewData["Permission"] = _permissionService.Get();
            ViewData["IsSuccess"] = true;
            return Page();
        }
    }
}
