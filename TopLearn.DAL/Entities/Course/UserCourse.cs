using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DAL.Entities.Course
{
    public class UserCourse
    {
        [Key]
        public int UserCourseId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourseId { get; set; }


        #region Nvigation Properties (Relations)

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        #endregion
    }
}
