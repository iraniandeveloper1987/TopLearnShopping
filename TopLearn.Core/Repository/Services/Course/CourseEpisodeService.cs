using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using TopLearn.Core.Code_Generator;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Core.Repository.Services.Course
{
    public class CourseEpisodeService : BaseService<CourseEpisode>, ICourseEpisodeService
    {
        private readonly TopLearnContext _context;

        public CourseEpisodeService(TopLearnContext context) : base(context)
        {
            _context = context;
        }

        public List<CourseEpisode> GetAllCourseEpisodesByCourseId(int courseId)
        {
            return _context.CourseEpisodes.Where(e => e.CourseId == courseId).ToList();
        }

        public bool AddCourseEpisode(CourseEpisode episode, IFormFile videoEpisodeUpload)
        {

            episode.EpisodeFileName = videoEpisodeUpload.FileName;

            var videoEpisodePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Videos/Episodes",
                episode.EpisodeFileName);

            #region Check Exist VideoEpisode  

            if (File.Exists(videoEpisodePath))
            {
                return false;
            }

            #endregion

            #region Save Video Episode

            SaveFile.SaveFile.Save(file: videoEpisodeUpload, videoEpisodePath);

            #endregion

            base.Add(episode);
            base.Save();
            return true;
        }

        public bool UpdateCourseEpisode(CourseEpisode episode, IFormFile videoEpisodeUpload)
        {


            if (videoEpisodeUpload != null)
            {

                episode.EpisodeFileName = videoEpisodeUpload.FileName;

                var videoEpisodePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Videos/Episodes",
                    episode.EpisodeFileName);

                #region Check Exist VideoEpisode  

                if (File.Exists(videoEpisodePath))
                {
                    return false;
                }

                #endregion

                #region Save Video Episode

                SaveFile.SaveFile.Save(file: videoEpisodeUpload, videoEpisodePath);

                #endregion


            }

            _context.Update(episode);
            _context.SaveChanges();

            return true;
        }
    }
}
