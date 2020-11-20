using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TopLearn.DAL.Entities.Course
{
    public class CourseGroup
    {
        [Key]
        public int GroupId { get; set; }


        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupTitle { get; set; }


        [Display(Name = "حذف شده ؟")]
        public bool IsDelete { get; set; }


        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }


        [ForeignKey("ParentId")]
        public List<CourseGroup> CourseGroups { get; set; }



        #region Navigation properties
        
        [InverseProperty("CourseGroup")]
        public List<Course> Courses { get; set; }


        [InverseProperty("SubCourseGroup")]
        public List<Course> SubGroup { get; set; }

        #endregion
    }

}
