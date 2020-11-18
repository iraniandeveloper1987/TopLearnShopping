using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;

namespace TopLearn.Web.Pages.Admin
{

    [CheckPermission((int)PermissionEnum.AdminPanel)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
