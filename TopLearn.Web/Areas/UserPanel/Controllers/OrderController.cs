using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TopLearn.Core.Enums;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Repository.Interfaces.Order;

namespace TopLearn.Web.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {

            _orderService = orderService;
        }


        public IActionResult AddOrder(int id)
        {
            var courseId = _orderService.AddOrder(User.Identity.Name, id);

            return RedirectToAction("ShowOrder", new { id = courseId });
        }



        public IActionResult ShowOrder(int id, bool finaly = false, bool error = false, DiscountStatusEnum disCountStatus=DiscountStatusEnum.None )
        {
            var userName = User.Identity.Name;

            var order = _orderService.GetOrderUserPanel(id, userName);

            if (order == null)
            {
                return NotFound();
            }

            ViewData["disCountStatus"] = disCountStatus;
            ViewData["finally"] = finaly;
            ViewData["Error"] = error;


            return View(order);
        }

        public IActionResult Index()
        {
            var model = _orderService.GetAllOrdersByUserName(User.Identity.Name);
            return View(model);
        }


        public IActionResult FinallyOrder(int id)
        {
            var result = _orderService.FinallyOrder(id, User.Identity.Name);
            if (!result)
            {
                return Redirect("/UserPanel/Order/ShowOrder/" + id + "?finaly=true&error=true");
            }

            return Redirect("/UserPanel/Order/ShowOrder/" + id + "?finaly=true");
        }
    }
}
