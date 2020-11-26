using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;

namespace TopLearn.Core.Repository.Services.Course
{
    public class CourseService : BaseService<DAL.Entities.Course.Course> , ICourseService
    {
        private  readonly TopLearnContext _context;
        public CourseService(TopLearnContext context) : base(context)
        {
            _context = context;
        }
    }
}
