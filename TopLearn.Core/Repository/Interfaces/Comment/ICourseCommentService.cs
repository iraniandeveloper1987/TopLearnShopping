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
        Tuple<List<CourseComment>, int> ShowCourseCommentsByCourseId(int courseId ,int currentPage=1 ,int take =5 );


    }
}
