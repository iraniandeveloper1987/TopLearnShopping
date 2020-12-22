using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopLearn.Core.Repository.Interfaces.Course;

namespace TopLearn.Web.Controllers
{
    public class ShortUrlController : Controller
    {
        private readonly ICourseService _courseService;

        public ShortUrlController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Route("c/{key}")]
        public IActionResult ShortCourseUrl(string key)
        {
            var course = _courseService.GetCourseByShortKey(key);

            return Redirect(Url.Content($"/ShowCourse/{course.CourseId}"));
        }
    }
}
