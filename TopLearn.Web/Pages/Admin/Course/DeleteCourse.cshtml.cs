using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs.Admin.Course;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces.Course;

namespace TopLearn.Web.Pages.Admin.Course
{
    [CheckPermission((int)PermissionEnum.DeleteCourse)]
    public class DeleteCourseModel : PageModel
    {
        private readonly ICourseService _courseService;

        public DeleteCourseModel(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [BindProperty]
        public ShowCourseForAdminViewModel Course { get; set; }

        public void OnGet(int id)
        {
            Course = _courseService.GetCourseByIdForAdmin(id);
        }


        public IActionResult OnPost()
        {
         
            _courseService.DeleteCourse(Course.Id);

            return RedirectToPage("Index");
        }
    }
}
