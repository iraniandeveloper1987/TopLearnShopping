using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TopLearn.Core.Repository.Interfaces.Course;


namespace TopLearn.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService _courseService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            var model = _courseService.GetCourses().Item1;
            return View(model);
        }


    }
}
