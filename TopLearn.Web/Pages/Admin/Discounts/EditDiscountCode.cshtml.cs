using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Convertors;
using TopLearn.Core.Repository.Interfaces.Discount;
using TopLearn.DAL.Entities.Discount;

namespace TopLearn.Web.Pages.Admin.Discounts
{
    public class EditDiscountCodeModel : PageModel
    {
        private readonly IDiscountService _discountService;

        public EditDiscountCodeModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [BindProperty]
        public Discount Discount { get; set; }
        public void OnGet(int discountId)
        {
            Discount = _discountService.GetById(discountId);
            ViewData["oldCode"] = Discount.DiscountCode;
        }


        public IActionResult OnPost(string StartDate, string EndDate)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _discountService.Update(Discount);
            _discountService.Save();

            return RedirectToPage("Index");
        }
    }
}
