using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TopLearn.Core.Repository.Interfaces.Discount;

namespace TopLearn.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpPost]
        public IActionResult UseDiscountCode(string discountCode, int orderId)
        {
            var result = _discountService.UseDiscountCode(orderId: orderId, discountCode: discountCode);
            return Redirect("/UserPanel/Order/ShowOrder?id=" + orderId + "&disCountStatus=" + result);
        }
    }
}
