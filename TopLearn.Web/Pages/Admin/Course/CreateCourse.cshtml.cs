using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Web.Pages.Admin.Course
{
    public class CreateCourseModel : PageModel
    {
        private readonly ICourseGroupService _courseGroupService;
        private readonly ICourseLevelService _courseLevelService;
        private readonly ICourseStatusService _courseStatusService;

        public CreateCourseModel(ICourseGroupService courseGroupService, ICourseLevelService courseLevelService, ICourseStatusService courseStatusService)
        {
            _courseGroupService = courseGroupService;
            _courseLevelService = courseLevelService;
            _courseStatusService = courseStatusService;
        }


        [BindProperty]
        public DAL.Entities.Course.Course Course { get; set; }

        public void OnGet()
        {
            var mainCourseGroup = _courseGroupService.GetMainCourseGroup();
            ViewData["MainCourseGroup"] = new SelectList(mainCourseGroup, "Value", "Text");

            List<SelectListItem> subGroupCourse = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "انتخاب کنید",
                    Value = "0"
                }
            };
            subGroupCourse.AddRange(_courseGroupService.GetSubCourseGroup(int.Parse(mainCourseGroup.FirstOrDefault().Value)));

            ViewData["SubCourseGroup"] = new SelectList(subGroupCourse, "Value", "Text");


            var courseLevels = _courseLevelService.GetAllCourseLevels();
            ViewData["CourseLevels"] = new SelectList(courseLevels, "Value", "Text");


            var courseStatuses = _courseStatusService.GetAllCourseStatus();
            ViewData["CourseStatuses"] = new SelectList(courseStatuses, "Value", "Text");
        }
    }
}
