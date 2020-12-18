using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.DTOs.Comment;
using TopLearn.Core.Repository.Interfaces.Comment;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Comment;

namespace TopLearn.Core.Repository.Services.Comment
{
    public class CourseCommentService : BaseService<CourseComment>, ICourseCommentService
    {
        private readonly TopLearnContext _context;
        public CourseCommentService(TopLearnContext context) : base(context)
        {
            _context = context;
        }

        public List<CourseComment> ShowCourseCommentsByCourseId(int courseId)
        {
            return _context.CourseComments
                .Include(c => c.User)
                .Where(c => c.CourseId == courseId && !c.IsDeleted).ToList();

        }
    }
}
