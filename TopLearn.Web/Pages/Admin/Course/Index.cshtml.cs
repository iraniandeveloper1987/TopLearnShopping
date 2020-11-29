using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Admin.Course;
using TopLearn.Core.Repository.Interfaces.Course;

namespace TopLearn.Web.Pages.Admin.Course
{
    public class IndexModel : PageModel
    {
        private readonly ICourseService _courseService;

        public IndexModel(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [BindProperty]
        public List<ShowCourseForAdminViewModel> Courses { get; set; }

        public void OnGet()
        {
            Courses = _courseService.GetAllCoursesForAdmin();
        }


    }
}
