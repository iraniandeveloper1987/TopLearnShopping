using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DAL.Entities.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double SumOrder { get; set; }

        [Required]
        public bool IsFinally { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        #region Navigartion Properties (Relations)

        public virtual List<OrderDetail> OrderDetails { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        #endregion
    }
}
