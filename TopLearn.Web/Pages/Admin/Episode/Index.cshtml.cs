using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Web.Pages.Admin.Episode
{
    public class IndexModel : PageModel
    {
        private readonly ICourseEpisodeService _courseEpisodeService;

        public IndexModel(ICourseEpisodeService courseEpisodeService)
        {
            _courseEpisodeService = courseEpisodeService;
        }

        [BindProperty]
        public List<CourseEpisode> CourseEpisodes { get; set; }
        public void OnGet(int courseId)
        {
            
            CourseEpisodes= _courseEpisodeService.GetAllCourseEpisodesByCourseId(courseId);

            ViewData["CourseId"] = courseId;
        }
    }
}
