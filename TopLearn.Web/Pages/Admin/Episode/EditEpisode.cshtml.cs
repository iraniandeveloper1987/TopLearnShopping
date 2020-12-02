using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Web.Pages.Admin.Episode
{
    public class EditEpisodeModel : PageModel
    {
        private readonly ICourseEpisodeService _courseEpisodeService;

        public EditEpisodeModel(ICourseEpisodeService courseEpisodeService)
        {
            _courseEpisodeService = courseEpisodeService;
        }

        [BindProperty]
        public CourseEpisode CourseEpisode { get; set; }

        public void OnGet(int episodeId)
        {
            CourseEpisode = _courseEpisodeService.GetById(episodeId);
        }

        public IActionResult OnPost(IFormFile episodeFileUpload)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = _courseEpisodeService.UpdateCourseEpisode(CourseEpisode, episodeFileUpload);

            if (!result)
            {
                ViewData["InvalidFileName"] = true;
                return Page();
            }

            return Redirect("/Admin/Episode/Index/" + CourseEpisode.CourseId);
        }
    }
}
