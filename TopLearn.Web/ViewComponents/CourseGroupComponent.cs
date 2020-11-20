using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TopLearn.Core.Repository.Interfaces.Course;

namespace TopLearn.Web.ViewComponents
{
    public class CourseGroupComponent : ViewComponent
    {
        private  readonly ICourseGroupService _courseGroupService;

        public CourseGroupComponent(ICourseGroupService courseGroupService)
        {
            _courseGroupService = courseGroupService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("CourseGroup", _courseGroupService.Get()));
        }
    }
}
