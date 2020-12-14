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
    public class CreateDiscountCodeModel : PageModel
    {
        private readonly IDiscountService _discountService;

        public CreateDiscountCodeModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [BindProperty]
        public Discount Discount { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string startDate, string endDate)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Discount.StartDate = startDate?.ShamsiToMIladi();
            Discount.EndDate = endDate?.ShamsiToMIladi();
            _discountService.Add(Discount);
            _discountService.Save();

            return RedirectToPage("Index");
        }

        public IActionResult OnGetCheckCode(string code)
        {
            var result = Content(_discountService.IsExistDiscountCode(code).ToString());
            return result;
        }

    }
}
