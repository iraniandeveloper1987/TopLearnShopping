using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Repository.Interfaces.Course;

namespace TopLearn.Web.Pages.Admin.Controllers
{
    public class AjaxController : Controller
    {
        private  readonly ICourseGroupService _courseGroupService;

        public AjaxController(ICourseGroupService courseGroupService)
        {
            _courseGroupService = courseGroupService;
        }

        public IActionResult GetSubCourseGroup(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = "0"}
            };
            list.AddRange(_courseGroupService.GetSubCourseGroup(id));
            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}
