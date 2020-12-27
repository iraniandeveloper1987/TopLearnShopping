using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.DAL.Entities.Course;

namespace TopLearn.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly ICourseGroupService _courseGroupService;
        private readonly ICourseVoteService _courseVoteService;
        private readonly IUserService _userService;

        public CourseController(ICourseService courseService, ICourseGroupService courseGroupService, ICourseVoteService courseVoteService, IUserService userService)
        {
            _courseService = courseService;
            _courseGroupService = courseGroupService;
            _courseVoteService = courseVoteService;
            _userService = userService;
        }

        public IActionResult Index(int pageId = 1, string filter = "", string getType = "all", string orderByType = "newDate",
            int minPrice = 0, int maxPrice = 0, List<int> selectedGroups = null, int take = 9)
        {
            ViewData["pageId"] = pageId;
            ViewData["Groups"] = _courseGroupService.Get();
            ViewData["SelectedGroup"] = selectedGroups;


            var model = _courseService.GetCourses(pageId, filter, getType, orderByType, minPrice, maxPrice, selectedGroups, take);
            return View(model);
        }

        [Route("ShowCourse/{courseId}/{courseTitle?}")]
        public IActionResult ShowCourse(int courseId, string courseTitle)
        {
            var model = _courseService.GetCourseById(courseId);

            return View(model);
        }

        public IActionResult CourseVote(int id)
        {
            var voteNumbers = _courseVoteService.ComputeVote(id);
            
            ViewData["CountLike"] =voteNumbers.Item1;
            ViewData["CountDislike"] = voteNumbers.Item2;

            return PartialView("_CourseVote");
        }

     
        [Authorize]
        public IActionResult AddVote(int id, bool vote)
        {
            var userId = _userService.GetUserIdByUserName(User.Identity.Name);
            _courseVoteService.AddVote(id, userId, vote);
            return Redirect(url: Url.Content($"/Course/CourseVote/{id}"));
        }
    }
}
