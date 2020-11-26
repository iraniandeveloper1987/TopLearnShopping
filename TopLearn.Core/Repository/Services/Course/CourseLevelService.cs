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
    public class CourseLevelService : BaseService<CourseLevel>, ICourseLevelService
    {
        private readonly TopLearnContext _context;

        public CourseLevelService(TopLearnContext context) : base(context)
        {
            _context = context;
        }


        public List<SelectListItem> GetAllCourseLevels()
        {
            return _context.CourseLevels.Select(l => new SelectListItem()
            {
                Value = l.LevelId.ToString(),
                Text = l.LevelTitle
            }).ToList();
        }
    }
}
