﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Interfaces.Course
{
    public interface ICourseGroupService :  IBaseService<CourseGroup>
    {
        List<SelectListItem> GetMainCourseGroup();
        List<SelectListItem> GetSubCourseGroup(int mainCourseGroup);

    }
}

