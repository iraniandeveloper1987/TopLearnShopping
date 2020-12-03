using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Enums;
using TopLearn.Core.FilterAttributes;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Web.Pages.Admin.Episode
{
    [CheckPermission((int)PermissionEnum.DeleteEpisode)]
    public class DeleteEpisodeModel : PageModel
    {
        private readonly ICourseEpisodeService _courseEpisodeService;

        public DeleteEpisodeModel(ICourseEpisodeService courseEpisodeService)
        {
            _courseEpisodeService = courseEpisodeService;
        }

        [BindProperty]
        public CourseEpisode CourseEpisode { get; set; }
        public void OnGet(int episodeId)
        {
            CourseEpisode = _courseEpisodeService.GetById(episodeId);
        }

        public IActionResult OnPost()
        {
            _courseEpisodeService.DeleteCourseEpisode(CourseEpisode);

            return Redirect("/Admin/Episode/Index/" + CourseEpisode.CourseId);
        }
    }
}
