using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TopLearn.Core.DTOs.Admin.Course
{
    public class ShowCourseForAdminViewModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string Title { get; set; }

        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string ImageName { get; set; }

        [MaxLength(50, ErrorMessage = "فیلد {0} نمی تواند بیشتر از {1} کاراکترباشد")]
        public string TeacherName { get; set; }

        public int EpisodeNumber { get; set; }

        public DateTime RegisterDate { get; set; }





    }
}
