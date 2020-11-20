using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopLearn.DAL.Entities.Course
{
   public class CourseStatus
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(150)]
        public string StatusTitle { get; set; }

        #region Navigation Properties

        public virtual List<DAL.Entities.Course.Course> Courses { get; set; }

        #endregion


    }
}
