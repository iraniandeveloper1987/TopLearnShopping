using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DAL.Entities.Comment
{
    public class CourseComment
    {
        [Key]
        public int CourseCommentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required(ErrorMessage = "لطفا فیلد {0} را وارد کنید")]
        [MaxLength(700, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Comment { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }

        public bool IsReadAdmin { get; set; }

        public bool IsDeleted { get; set; }

        public int? CommentParentId { get; set; }

        #region Navigation Properties (Relations)

        [ForeignKey("CourseId")]
        public virtual Course.Course Course { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CommentParentId")]
        public virtual List<CourseComment> ParentComment { get; set; }


        #endregion  

    }
}
