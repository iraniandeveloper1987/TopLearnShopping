using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Services.Course
{
    public class CourseStatusService : BaseService<CourseStatus>, ICourseStatusService
    {
        private readonly TopLearnContext _context;
        public CourseStatusService(TopLearnContext context) : base(context)
        {
            _context = context;
        }


        public List<SelectListItem> GetAllCourseStatus()
        {
            return _context.CourseStatuses.Select(s => new SelectListItem()
            {
                Value = s.StatusId.ToString(),
                Text = s.StatusTitle
            }).ToList();
        }
    }
}
