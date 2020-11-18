using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Code_Generator;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs;
using TopLearn.Core.DTOs.Account;
using TopLearn.Core.DTOs.AccountViewModels;
using TopLearn.Core.messaging.Interfaces;
using TopLearn.Core.messaging.Services;
using TopLearn.Core.Repository.Interfaces.Role;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.Core.Security;
using TopLearn.Core.States;
using TopLearn.DAL.Entities;

namespace TopLearn.Web.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleUserService _roleUserService;
        private readonly IMessaging _messaging;

        public AccountController(IUserService userService, IRoleUserService roleUserService, IMessaging messaging)
        {
            _userService = userService;
            _roleUserService = roleUserService;
            _messaging = messaging;
        }

        #region Properties

        private string GetNameOfMessagingProvider
        {
            get
            {
                var providerName = HttpContext.RequestServices.GetService(typeof(IMessaging)).ToString() == typeof(SmsService).FullName ? "موبایل" : "ایمیل";

                return providerName;
            }
        }

        #endregion

        #region Register


        [Route("Register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_userService.IsExistEmail(model.Email.EmailFixed()))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا در سیستم ثبت نام شده است ");
                return View(model);
            }

            if (_userService.IsExistMobile(model.Mobile))
            {
                ModelState.AddModelError("Mobile", "موبایل وارد شده قبلا در سیستم ثبت نام کرده است");
                return View(model);
            }



            if (_userService.IsExistUserName(model.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده قبلا در سیستم ثبت نام کرده است");
                return View(model);
            }


            var user = new User()
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
                Mobile = model.Mobile,
                Password = PasswordHelper.EncodePasswordMd5(model.Password),
                IsActive = false,
                RegisterDate = DateTime.Now,
                UserAvatar = "Default.jpg",
                ActiveCode = ActiveCode.Generate()
            };
            _userService.Add(user);
            _userService.Save();


            RoleUser roleUser = new RoleUser()
            {
                RoleId = (int)RoleEnum.User,
                UserId = user.UserId
            };
            _roleUserService.Add(roleUser);
            _roleUserService.Save();



            //ToDo: Send Active Code(Email or SMS) & RedirectToAction ActiveUser

            //var to = user.Email; For Email

            // var to = user.Mobile; For SMS

            var to = HttpContext.RequestServices.GetService(typeof(IMessaging)).ToString() == typeof(SmsService).FullName ? user.Mobile : user.Email;
            var subject = "فعال سازی حساب کاربری";
            var message = "به فروشگاه اینترنی تاپ لرن خوش آمدید" + Environment.NewLine + string.Format(":کد فعال سازی شما   {0} ", user.ActiveCode);

            SendActivationCodeByeEmailOrSms(to, message, subject);

            return RedirectToAction("ActiveUser", "Account");


        }

        private void SendActivationCodeByeEmailOrSms(string to, string message, string subject)
        {
            _messaging.Send(to, subject, message);
        }


        #endregion

        #region Active Users


        [Route("ActiveUser")]
        public IActionResult ActiveUser()
        {

            var providerName = GetNameOfMessagingProvider;

            ViewData["Message"] = string.Format("جهت فعال سازی حساب خود ، کد ارسال شده به {0} خود را وارد کنید", providerName);

            return View();
        }




        [HttpPost]
        [Route("ActiveUser")]
        [ValidateAntiForgeryToken]
        public IActionResult ActiveUser(ActiveViewModel model)

        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userService.GetUserByActiveCode(model.ActiveCode);

            if (user == null)
            {
                ModelState.AddModelError("ActiveCode", "کد فعال سازی نا معتبر می باشد");
                return View(model);
            }

            user.IsActive = true;

            _userService.Update(user);
            _userService.Save();

            @ViewData["SuccessMesssage"] = "حساب کاربری شما با موفقیت فعال شد";

            return View(model);
        }

        #endregion

        #region ForgetPassword

        [Route("ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgetPassword")]
        [ValidateAntiForgeryToken]

        public IActionResult ForgetPassword(ForgetPasswordByEmailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            string to = string.Empty;
            string subject = string.Empty;
            string message = string.Empty;



            var user = _userService.GetUserByEmail(model.Email.EmailFixed());


            if (user == null)
            {
                ModelState.AddModelError("Email", "چنین ایمیلی در سیستم ثبت نشده است");
                return View(model);
            }

            else if (!user.IsActive)
            {

                ViewData["ErrorMeesage"] = "کاربر گرامی اکانت شما غیر فعال می باشد";


                to = HttpContext.RequestServices.GetService(typeof(IMessaging)).ToString() == typeof(SmsService).FullName ? user.Mobile : user.Email;
                subject = "فعال سازی حساب کاربری";
                message = "به فروشگاه اینترنی تاپ لرن خوش آمدید" + Environment.NewLine + string.Format(":کد فعال سازی شما   {0} ", user.ActiveCode);

                SendActivationCodeByeEmailOrSms(to, message, subject);

                return View(model);
            }


            ViewData["SuccessMeesage"] = $"کلمه عبور جدید به {GetNameOfMessagingProvider} ارسال شد";

            var newpassword = ActiveCode.Generate();

            to = HttpContext.RequestServices.GetService(typeof(IMessaging)).ToString() == typeof(SmsService).FullName ? user.Mobile : user.Email;
            subject = "ارسال کلمه عبور جدید";
            message = "به فروشگاه اینترنی تاپ لرن خوش آمدید" + Environment.NewLine + string.Format(":کلمه عبور جدید شما   {0} ", newpassword);

            SendActivationCodeByeEmailOrSms(to, message, subject);

            user.Password = PasswordHelper.EncodePasswordMd5(newpassword);

            _userService.Update(user);
            _userService.Save();


            return View(model);
        }

        #endregion

        #region Login

        [Route("Login")]

        public IActionResult LogIn(string ReturnUrl = null, bool EditProfile = false)
        {
            ViewData["ReturnUrl"] = ReturnUrl;

            ViewData["EditProfile"] = EditProfile;

            return View();
        }

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(LoginMobileViewModel model, string ReturnUrl = null, bool EditProfile = false)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewData["EditProfile"] = EditProfile;


            var user = _userService.LoginByMobile(model.Mobile,
                PasswordHelper.EncodePasswordMd5(model.Password));

            ViewData["ReturnUrl"] = ReturnUrl;

            if (user == null)
            {
                ModelState.AddModelError("Password", "اطلاعات وارد شده اشتباه می باشد");
                return View(model);
            }

            else if (!user.IsActive)
            {

                // send Active Code BY Email or Sms

                var to = HttpContext.RequestServices.GetService(typeof(IMessaging)).ToString() == typeof(SmsService).FullName ? user.Mobile : user.Email;
                var subject = "فعال سازی حساب کاربری";
                var message = "به فروشگاه اینترنی تاپ لرن خوش آمدید" + Environment.NewLine + string.Format("کد فعال سازی شما :  {0} ", user.ActiveCode);

                SendActivationCodeByeEmailOrSms(to, message, subject);

                return RedirectToAction("ActiveUser", "Account");
            }


            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.MobilePhone,  user.Mobile),
                new Claim("FullName",user.FullName),
                new Claim(ClaimTypes.Email,user.Email)
            };


            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties()
            {
                IsPersistent = model.RememberMe
            };

            HttpContext.SignInAsync(principal, properties);

            ViewData["IsSuccsessMessqage"] = "ورود شما با موفقیت انجام شد";

            if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }

            return View(model);


        }

        #endregion

        #region Logout

        [Route("Logout")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");

        }

        #endregion



    }
}
