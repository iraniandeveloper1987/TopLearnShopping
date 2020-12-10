using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.DAL.Entities.Discount
{

    public class UserDiscount
    {
        [Key]
        public int UserDiscountId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int DiscountId { get; set; }

        #region Navigation Properties (Relations)

        public User User { get; set; }
        public Discount Discount { get; set; }

        #endregion
    }

}
