using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DAL.Entities.Order
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }

        #region Navigartion Properties (Relations)

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course.Course Course { get; set; }

        #endregion
    }
}
