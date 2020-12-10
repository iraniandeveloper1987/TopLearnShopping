using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.DAL.Entities.Discount
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }

        [Display(Name = "کد تخفیف")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string DiscountCode { get; set; }

        [Display(Name = "تعداد کد قابل استفاده")]
        public int? UsableCount { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        public int DiscountPercent { get; set; }


        [Display(Name = "تاریخ شروع تخفیف")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "تاریخ پایان تخفیف")]
        public DateTime? EndDate { get; set; }


        #region Navigation Properties (Relations)

        public virtual List<UserDiscount> UserDiscounts { get; set; }

        #endregion



    }
}
