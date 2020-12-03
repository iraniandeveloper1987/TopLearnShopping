using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using TopLearn.Core.Services.Interfaces.Base;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Interfaces.Course
{
    public interface ICourseEpisodeService : IBaseService<CourseEpisode>
    {

        List<CourseEpisode> GetAllCourseEpisodesByCourseId(int courseId);

        bool AddCourseEpisode(CourseEpisode episode, IFormFile videoEpisodeUpload);

        bool UpdateCourseEpisode(CourseEpisode episode, IFormFile videoEpisodeUpload);

        bool DeleteCourseEpisode(CourseEpisode episode);
    }
}
