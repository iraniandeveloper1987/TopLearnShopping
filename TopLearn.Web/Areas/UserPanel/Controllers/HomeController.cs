using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs.UserPanel;
using TopLearn.Core.Repositories;
using TopLearn.Core.Security;

namespace TopLearn.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetUserInfoes(User.Identity.Name));
        }

        [Route("UserPanel/EditProfile")]
        public IActionResult EditProfileUser()
        {

            return View(_userService.GetEditProfile(User.Identity.Name));
        }

        [HttpPost]
        [Route("UserPanel/EditProfile")]
        [ValidateAntiForgeryToken]
        public IActionResult EditProfileUser(EditProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            _userService.EditProfile(User.Identity.Name, model);

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return Redirect("/Login?EditProfile=True");

        }

        [Route("UserPanel/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("UserPanel/ChangePassword")]
        [ValidateAntiForgeryToken]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userService.GetUserByUserName(User.Identity.Name);

            try
            {
                user.Password = PasswordHelper.EncodePasswordMd5(model.NewPassword);
                _userService.Save();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Login?EditProfile=True");
        }


    }

}
