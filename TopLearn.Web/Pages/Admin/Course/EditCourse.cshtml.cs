using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces.Course;

namespace TopLearn.Web.Pages.Admin.Course
{
    [CheckPermission((int)PermissionEnum.EditCourse)]
    public class EditCourseModel : PageModel
    {
        private readonly ICourseService _courseService;
        private readonly ICourseGroupService _courseGroupService;
        private readonly ICourseLevelService _courseLevelService;
        private readonly ICourseStatusService _courseStatusService;

        public EditCourseModel(ICourseGroupService courseGroupService, ICourseLevelService courseLevelService, ICourseStatusService courseStatusService, ICourseService courseService)
        {
            _courseGroupService = courseGroupService;
            _courseLevelService = courseLevelService;
            _courseStatusService = courseStatusService;
            _courseService = courseService;
        }


        [BindProperty]
        public DAL.Entities.Course.Course Course { get; set; }


        public void OnGet(int id)
        {

            Course = _courseService.GetById(id);

            var mainCourseGroup = _courseGroupService.GetMainCourseGroup();
            ViewData["MainCourseGroup"] = new SelectList(mainCourseGroup, "Value", "Text", Course.GroupId);


            List<SelectListItem> subGroupCourse = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "انتخاب کنید",
                    Value = "0"
                }
            };

            if (Course.SubGroup != null)
            {
                subGroupCourse.AddRange(_courseGroupService.GetSubCourseGroup(Course.GroupId));
            }

            ViewData["SubCourseGroup"] = new SelectList(subGroupCourse, "Value", "Text", Course.SubGroup);



            var courseLevels = _courseLevelService.GetAllCourseLevels();
            ViewData["CourseLevels"] = new SelectList(courseLevels, "Value", "Text", Course.LevelId);


            var courseStatuses = _courseStatusService.GetAllCourseStatus();
            ViewData["CourseStatuses"] = new SelectList(courseStatuses, "Value", "Text", Course.StatusId);


            var teachers = _courseService.GetAllTeachers();
            ViewData["Teachers"] = new SelectList(teachers, "Value", "Text", Course.TeacherId);
        }

        public IActionResult OnPost(IFormFile demoFileUpload, IFormFile imageCourseFileUpload)
        {
            if (!ModelState.IsValid)
                return Page();


            _courseService.UpdateCourse(course: Course, imageCourseFileUpload, demoFileUpload);
            return RedirectToPage("Index");
        }


    }

}
