using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.DTOs.Admin.Course;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Interfaces.Course
{
    public interface ICourseService : IBaseService<DAL.Entities.Course.Course>
    {
        List<SelectListItem> GetAllTeachers();

        int AddCourse(DAL.Entities.Course.Course course, IFormFile courseImageUp, IFormFile demoFileUp);

        bool UpdateCourse(DAL.Entities.Course.Course course, IFormFile courseImageUp, IFormFile demoFileUp);

        List<ShowCourseForAdminViewModel> GetAllCoursesForAdmin();
    }
}
