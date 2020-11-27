using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.Code_Generator;
using TopLearn.Core.Repository.Interfaces.Course;
using TopLearn.Core.SaveFile;
using TopLearn.Core.Services.ServiceBase;
using TopLearn.DAL.Context;

namespace TopLearn.Core.Repository.Services.Course
{
    public class CourseService : BaseService<DAL.Entities.Course.Course>, ICourseService
    {
        private readonly TopLearnContext _context;

        public CourseService(TopLearnContext context) : base(context)
        {
            _context = context;
        }

        public List<SelectListItem> GetAllTeachers()
        {
            return _context.RoleUsers
                .Where(u => u.RoleId == 2)
                .Include(u => u.User)
                .Select(u => new SelectListItem()
                {
                    Text = u.User.FullName,
                    Value = u.User.UserId.ToString()
                }).ToList();
        }

        public int AddCourse(DAL.Entities.Course.Course course, IFormFile courseImageUp, IFormFile demoFileUp)
        {

            course.CreateDate = DateTime.Now;
            course.CourseImageName = "DefaultCourse.jpg";

            if (courseImageUp != null)
            {
                #region Save Image

                course.CourseImageName = NameGenerator.Generate() + Path.GetExtension(courseImageUp.FileName);

                var physicalAddressImageFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/",
                    course.CourseImageName);

                SaveFile.SaveFile.Save(courseImageUp, physicalAddressImageFile);


                #endregion

            }

            if (demoFileUp != null)
            {
                #region Save Image

                course.DemoFileName = NameGenerator.Generate() + Path.GetExtension(demoFileUp.FileName);

                var physicalAddressDemoFile = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/images/Courses/Demo/",
                    course.DemoFileName);

                SaveFile.SaveFile.Save(courseImageUp, physicalAddressDemoFile);


                #endregion
            }

            _context.Add(course);
            _context.SaveChanges();


            return course.CourseId;
        }
    }
}
