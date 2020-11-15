using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using TopLearn.Core.DTOs.Wallet;
using TopLearn.Core.Repository.Interfaces;

namespace TopLearn.Web.Areas.UserPanel.Controllers
{

    [Area("UserPanel")]
    [Authorize]
    public class WalletController : Controller
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }



        [Route("UserPanel/Wallet/{currentPage?}")]
        public IActionResult Index(int currentPage = 1)
        {
            var username = User.Identity.Name;



            int numberSteps;

            ManageWalletViewModel manageWallet = new ManageWalletViewModel()
            {

                wallets = _walletService.GetAllWalletsWithPaging(username, out numberSteps, currentPage, 5),
                AccountBalance = _walletService.AccountBalance(username)

            };

            currentPage = (currentPage < 1) ? 1 : currentPage;

            ViewData["currentPage"] = currentPage;

            ViewData["numberSteps"] = numberSteps;

            return View(manageWallet);
        }

        [HttpPost]
        [Route("UserPanel/Wallet/{currentPage?}")]
        public IActionResult Index(ManageWalletViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var walletId = _walletService.ChargeWallet(User.Identity.Name, model.ChargeWallet.Amount);

            // ToDo: Go To Online ZarinpalGetWay 

            #region Online Payment

            var user = _walletService.GetUserByWalletId(walletId);

            var paymentOnline = new ZarinpalSandbox.Payment(model.ChargeWallet.Amount);

            var res = paymentOnline.PaymentRequest("شارژ کیف پول", "https://localhost:5001/UserPanel/OnlinePayWallet/" + walletId, email: user.Email, mobile: user.Mobile);

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion

            ViewData["MessageField"] = "متاسفانه در حال حاظر امکان ارتباط با درگاه پرداخت امکانپذیر نمی باشد  ";

            return View(model);


        }





    }
}
