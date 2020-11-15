using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Repositories;
using TopLearn.Core.Security;

namespace TopLearn.Web.Areas.UserPanel.Controllers
{

    [Area("UserPanel")]
    [Authorize]
    public class RemoteValidationsController : Controller
    {
        private IUserService _userService;

        public RemoteValidationsController(IUserService userService)
        {
            _userService = userService;
        }



        public IActionResult IsExistCurrentPassword(string currentpassword)
        {
            if (_userService.IsExistCurrentPassword(PasswordHelper.EncodePasswordMd5(currentpassword)))
            {
                return Json(true);

            }
            return Json("کلمه عبور فعلی شما اشتباه می باشد");

        }
    }
}

