using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Services.Course
{
    public class CourseGroupService : BaseService<CourseGroup> , ICourseGroupService
    {
        private  readonly TopLearnContext _context;
        public CourseGroupService(TopLearnContext context) : base(context)
        {
            _context = context;
        }


    }
}
