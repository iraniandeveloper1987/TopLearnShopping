using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TopLearn.Core.Repository.Interfaces.Course;

namespace TopLearn.Web.Controllers
{
    [Authorize]
    public class DownloadController : Controller
    {
        private readonly ICourseEpisodeService _episodeService;
        private readonly IUserCourseService _userCourseService;

        public DownloadController(ICourseEpisodeService episodeService, IUserCourseService userCourseService)
        {
            _episodeService = episodeService;
            _userCourseService = userCourseService;
        }

        [Route("DownloadFile/{episodeId}")]
        public IActionResult DownloadEpisode(int episodeId)
        {
            var episode = _episodeService.GetById(episodeId);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Videos/Episodes",
                episode.EpisodeFileName);
            string fileName = episode.EpisodeFileName;

            if (episode.IsFree)
            {
                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", fileName);
            }

            if (User.Identity.IsAuthenticated)
            {
                if (_userCourseService.IsExistUserInCourse(User.Identity.Name , episode.CourseId))
                {

                    byte[] file = System.IO.File.ReadAllBytes(filepath);
                    return File(file, "application/force-download", fileName);
                }
            }

            return Forbid();
        }
    }
}
