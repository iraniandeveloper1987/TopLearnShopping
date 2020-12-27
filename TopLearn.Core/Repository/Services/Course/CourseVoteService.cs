using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Services.Course
{
    public class CourseVoteService : BaseService<CourseVote>, ICourseVoteService
    {
        private readonly TopLearnContext _context;

        public CourseVoteService(TopLearnContext context) : base(context)
        {
            _context = context;
        }

        public void AddVote(int courseId, int UserId, bool vote)
        {

            var userVote = _context.CourseVotes
                .FirstOrDefault(cv => cv.CourseId == courseId && cv.UserId == UserId);

            if (userVote != null)
            {
                userVote.Vote = vote;
                _context.CourseVotes.Update(userVote);
            }
            else
            {
                userVote = new CourseVote()
                {
                    UserId = UserId,
                    CourseId = courseId,
                    Vote = vote
                };
                _context.CourseVotes.Add(userVote);
            }


            _context.SaveChanges();
        }

        public Tuple<int, int> ComputeVote(int courseId)
        {
            var likeNumbers = _context.CourseVotes.Count(cv => cv.CourseId == courseId && cv.Vote == true);
            var disLikeNumbers = _context.CourseVotes.Count(cv => cv.CourseId == courseId && cv.Vote == false);
            return Tuple.Create(likeNumbers, disLikeNumbers);
        }
    }
}
