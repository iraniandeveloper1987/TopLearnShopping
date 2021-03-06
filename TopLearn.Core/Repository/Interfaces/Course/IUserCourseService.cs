﻿using System;
using System.Collections.Generic;
using System.Text;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Interfaces.Course
{
    public interface IUserCourseService : IBaseService<UserCourse>
    {
        bool IsExistUserInCourse(string userName , int courseId);
    }
}
