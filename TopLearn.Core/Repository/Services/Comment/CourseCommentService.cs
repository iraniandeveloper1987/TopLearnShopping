using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kavenegar.Core.Models;
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

        public Tuple<List<CourseComment>, int> ShowCourseCommentsByCourseId(int courseId, int currentPage = 1, int take = 5)
        {
            var skip = (currentPage - 1) * take;

            var allComments = _context.CourseComments
                .Include(c => c.User)
                .Where(c => c.CourseId == courseId && !c.IsDeleted).ToList();

            var countPage = allComments.Count % take == 0 ? allComments.Count / take : (allComments.Count / take) + 1;


            var comments = _context.CourseComments
                .Include(c => c.User)
                .Where(c => c.CourseId == courseId && !c.IsDeleted).Skip(skip).Take(take).ToList();

            return Tuple.Create(comments, countPage);

        }
    }
}
