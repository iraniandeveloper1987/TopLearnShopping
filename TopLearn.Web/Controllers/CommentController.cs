using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using TopLearn.Core.DTOs.Comment;
using TopLearn.Core.Repository.Interfaces.Comment;
using TopLearn.Core.Repository.Interfaces.User;
using TopLearn.DAL.Entities.Comment;

namespace TopLearn.Web.Controllers
{

    public class CommentController : Controller
    {
        private readonly ICourseCommentService _courseCommentService;

        private readonly IUserService _userService;

        public CommentController(ICourseCommentService courseCommentService, IUserService userService)
        {
            _courseCommentService = courseCommentService;
            _userService = userService;
        }



        public IActionResult ShowCourseComments(int id, int currentPage = 1, int take = 5)
        {
            ViewData["courseId"] = id;
            ViewData["currentPage"] = currentPage;

            var model = _courseCommentService.ShowCourseCommentsByCourseId(id, currentPage, take);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCommentForCourse(CourseComment comment)
        {
            comment.UserId = _userService.GetUserIdByUserName(User.Identity.Name);
            comment.RegisterDate = DateTime.Now;
            comment.IsDeleted = false;
            comment.IsReadAdmin = false;

            _courseCommentService.Add(comment);
            _courseCommentService.Save();

            return RedirectToAction("ShowCourseComments", "Comment", new { id = comment.CourseCommentId });
        }

    }
}
