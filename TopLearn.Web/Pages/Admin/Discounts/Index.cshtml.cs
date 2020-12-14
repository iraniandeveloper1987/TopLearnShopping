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
    public class IndexModel : PageModel
    {
        private readonly IDiscountService _discountService;

        public IndexModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [BindProperty]
        public List<Discount> Discounts { get; set; }

        public void OnGet()
        {
            Discounts = _discountService.Get().ToList();
        }
    }
}
