using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.Core.DTOs.Comment
{
    public class CourseCommentsViewModel
    {
        public int CourseCommentId { get; set; }

       
        public string CommenterName { get; set; }

        public string CommenterImageName { get; set; }

        [MaxLength(700, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Comment { get; set; }

        public DateTime RegisterDate { get; set; }  
    }
}
