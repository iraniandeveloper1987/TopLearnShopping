using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Repository.Interfaces.Discount;
using TopLearn.DAL.Entities.Discount;

namespace TopLearn.Web.Pages.Admin.Discounts
{
    public class DeleteDiscountCodeModel : PageModel
    {
        private readonly IDiscountService _discountService;

        public DeleteDiscountCodeModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [BindProperty]
        public Discount Discount { get; set; }

        public IActionResult OnGet(int discountCode)
        {
            //Discount = _discountService.GetById(discountCode);
            _discountService.Delete(discountCode);
            _discountService.Save();
            return RedirectToPage("Index");
        }

        //public IActionResult OnPost(int discountCode)
        //{
        //    _discountService.Delete(discountCode);
        //    _discountService.Save();

        //    return RedirectToPage("Index");
        //}
    }
}
