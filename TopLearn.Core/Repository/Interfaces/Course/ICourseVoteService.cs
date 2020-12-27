using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Interfaces.Course
{
    public interface ICourseVoteService : IBaseService<CourseVote>
    {
        void AddVote(int courseId , int UserId , bool vote);
        Tuple<int, int> ComputeVote(int courseId);
    }

    
}
