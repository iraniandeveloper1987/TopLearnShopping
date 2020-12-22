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

        ShowCourseForAdminViewModel GetCourseByIdForAdmin(int courseId);

        bool DeleteCourse(int id);

        Tuple<List<ShowCourseListItemViewModel>, int> GetCourses(int pageId = 1, string filter = ""
            , string getType = "all", string orderByType = "newDate",
            int minPrice = 0, int maxPrice = 0, List<int> selectedGroups = null, int take = 8);

        DAL.Entities.Course.Course GetCourseById(int courseId);

        int AttendantCourseCount(int courseId);

        DAL.Entities.Course.Course GetCourseByShortKey(string key);

    }


}
