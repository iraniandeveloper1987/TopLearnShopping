using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Repository.Interfaces;

namespace TopLearn.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class OnlinePayController : Controller
    {
        private IWalletService _walletService;


        public OnlinePayController(IWalletService walletService)
        {
            _walletService = walletService;
        }


        [Route("UserPanel/OnlinePayWallet/{walletId}")]
        public IActionResult OnlinePayWallet(int walletId)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var wallet = _walletService.GetWalletByWalletId(walletId);

                var payment = new ZarinpalSandbox.Payment(wallet.Amount);

                var res = payment.Verification(authority).Result;

                if (res.Status == 100)
                {
                    ViewData["TrackingCode"] = res.RefId;

                    wallet.IsPay = true;

                    _walletService.Update(wallet);

                    _walletService.Save();

                    ViewData["SuccessMessage"] = $"{User.Claims.FirstOrDefault(c => c.Type == "FullName").Value} عزیز پرداخت شما با موفقیت انجام شد";

                    return View();
                }

              
            }

            ViewData["FieldPayMessage"] = $"{User.Claims.FirstOrDefault(c => c.Type == "FullName").Value} عزیز پرداخت شما با شکست مواجه شد در صورت کم شدن مبلغ از حساب شما" +
                                          $" تا 72 ساعت آینده به حساب شما بازگشت خواهد داده شد";
            
            return View();
        }


    }
}
