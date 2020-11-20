using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopLearn.DAL.Entities.Course
{
   public class CourseLevel
    {
        [Key]
        public int LevelId { get; set; }

        [MaxLength(150)]
        [Required]
        public string LevelTitle { get; set; }

        #region Navigation Properties

        public virtual List<DAL.Entities.Course.Course> Courses { get; set; }

        #endregion

    }
}
