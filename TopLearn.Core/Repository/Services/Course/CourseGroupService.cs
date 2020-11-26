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
    public class CourseGroupService : BaseService<CourseGroup>, ICourseGroupService
    {
        private readonly TopLearnContext _context;
        public CourseGroupService(TopLearnContext context) : base(context)
        {
            _context = context;
        }


        public List<SelectListItem> GetMainCourseGroup()
        {
            return _context.CourseGroups
                .Where(cg => cg.ParentId == null)
                .Select(cg => new SelectListItem()
                {
                    Text = cg.GroupTitle,
                    Value = cg.GroupId.ToString()
                }).ToList();
        }

        public List<SelectListItem> GetSubCourseGroup(int mainCourseGroup)
        {
            return _context.CourseGroups
                .Where(cg => cg.ParentId == mainCourseGroup)
                .Select(cg => new SelectListItem()
                {
                    Text = cg.GroupTitle,
                    Value = cg.GroupId.ToString()
                }).ToList();
        }
    }
}

