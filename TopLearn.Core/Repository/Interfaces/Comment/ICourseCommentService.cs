using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.DTOs.Comment;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities.Comment;

namespace TopLearn.Core.Repository.Interfaces.Comment
{
    public interface ICourseCommentService : IBaseService<CourseComment>
    {
        List<CourseComment> ShowCourseCommentsByCourseId(int courseId);
        

    }
}
