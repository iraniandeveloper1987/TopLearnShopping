using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Services.Course
{
    public class UserCourseService : BaseService<UserCourse>, IUserCourseService
    {
        private readonly TopLearnContext _context;
        private readonly IUserService _userService;
        public UserCourseService(TopLearnContext context, IUserService userService) : base(context)
        {
            _context = context;
            _userService = userService;
        }

        public bool IsExistUserInCourse(string userName, int courseId)
        {
            var userId = _userService.GetUserIdByUserName(userName);
            return _context.UserCourses.Any(uc => uc.UserId == userId && uc.CourseId == courseId);
        }
    }

}
