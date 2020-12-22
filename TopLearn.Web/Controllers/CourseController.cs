using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopLearn.Core.Repository.Interfaces.Course;

namespace TopLearn.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICourseGroupService _courseGroupService;

        public CourseController(ICourseService courseService, ICourseGroupService courseGroupService)
        {
            _courseService = courseService;
            _courseGroupService = courseGroupService;
        }

        public IActionResult Index(int pageId = 1, string filter = "", string getType = "all", string orderByType = "newDate",
            int minPrice = 0, int maxPrice = 0, List<int> selectedGroups = null, int take = 9)
        {
            ViewData["pageId"] = pageId;
            ViewData["Groups"] = _courseGroupService.Get();
            ViewData["SelectedGroup"] = selectedGroups;


          var model = _courseService.GetCourses(pageId, filter, getType, orderByType, minPrice, maxPrice, selectedGroups, take);
            return View(model);
        }

        [Route("ShowCourse/{courseId}/{courseTitle?}")]
        public IActionResult ShowCourse(int courseId , string courseTitle)
        {
            ViewData["AttendantCourseCount"] = _courseService.AttendantCourseCount(courseId);
            var model = _courseService.GetCourseById(courseId);

            return View(model);
        }
    }
}
