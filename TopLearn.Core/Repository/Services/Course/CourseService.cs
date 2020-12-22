using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopLearn.Core.Code_Generator;
using TopLearn.Core.Convertors;
using TopLearn.Core.DTOs.Admin.Course;
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
            course.SubGroup = (course.SubGroup == 0) ? null : course.SubGroup;


            var shortKeyUrl = ShortKeyUrlGenerator.Generate(5);


            #region CheckExistShortKeyUrl

            while (_context.Courses.Any(c => c.ShortKey == shortKeyUrl))
            {
                shortKeyUrl = ShortKeyUrlGenerator.Generate(5);

            }

            #endregion


            course.ShortKey = shortKeyUrl;

            course.CourseImageName = "DefaultCourse.jpg";

            var physicalAddressImageFile = string.Empty;

            if (courseImageUp != null)
            {
                #region Save Image

                course.CourseImageName = NameGenerator.Generate() + Path.GetExtension(courseImageUp.FileName);

                physicalAddressImageFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/",
                   course.CourseImageName);

                SaveFile.SaveFile.Save(courseImageUp, physicalAddressImageFile);


                #endregion

            }


            //ToDo: Resize Image as thumbnail

            var inputImagePath = physicalAddressImageFile;

            var outPutImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/Thumbnail/",
                course.CourseImageName);


            ImageResize.Resize(input_Image_Path: inputImagePath, output_Image_Path: outPutImagePath, 100);



            if (demoFileUp != null)
            {
                #region Save Image

                course.DemoFileName = NameGenerator.Generate() + Path.GetExtension(demoFileUp.FileName);

                var physicalAddressDemoFile = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/images/Courses/Demo/",
                    course.DemoFileName);

                SaveFile.SaveFile.Save(demoFileUp, physicalAddressDemoFile);


                #endregion
            }

            _context.Add(course);
            _context.SaveChanges();


            return course.CourseId;
        }

        public bool UpdateCourse(DAL.Entities.Course.Course course, IFormFile courseImageUp, IFormFile demoFileUp)
        {

            try
            {
                course.UpdateDate = DateTime.Now;
                course.SubGroup = (course.SubGroup == 0) ? null : course.SubGroup;


                var physicalAddressImageFile = string.Empty;

                if (courseImageUp != null && course.CourseImageName != "DefaultCourse.jpg")
                {

                    #region Check Exist Main Course Image  And Delete

                    var mainImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses",
                         course.CourseImageName);


                    if (File.Exists(mainImagePath))
                    {
                        File.Delete(mainImagePath);
                    }

                    #endregion

                    #region Check Exist Thumbnail Course Image  And Delete

                    var thumbImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/Thumbnail",
                        course.CourseImageName);


                    if (File.Exists(thumbImagePath))
                    {
                        File.Delete(thumbImagePath);
                    }

                    #endregion

                    #region Save Main Course Image

                    course.CourseImageName = NameGenerator.Generate() + Path.GetExtension(courseImageUp.FileName);

                    physicalAddressImageFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/",
                        course.CourseImageName);

                    SaveFile.SaveFile.Save(courseImageUp, physicalAddressImageFile);


                    #endregion



                    #region Resize And Seve Main Image Course As Thumbnail

                    var inputImagePath = physicalAddressImageFile;

                    var outPutImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/Thumbnail/",
                        course.CourseImageName);

                    ImageResize.Resize(input_Image_Path: inputImagePath, output_Image_Path: outPutImagePath, 120);

                    #endregion
                }

                if (demoFileUp != null)
                {
                    #region Check Exist Demo Course Image  And Delete

                    var demoImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/Demo",
                        course.DemoFileName);


                    if (File.Exists(demoImagePath))
                    {
                        File.Delete(demoImagePath);
                    }

                    #endregion

                    #region Save  Demo File For Course

                    course.DemoFileName = NameGenerator.Generate() + Path.GetExtension(demoFileUp.FileName);

                    var physicalAddressDemoFile = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/images/Courses/Demo/",
                        course.DemoFileName);

                    SaveFile.SaveFile.Save(demoFileUp, physicalAddressDemoFile);


                    #endregion
                }

                _context.Courses.Update(course);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public List<ShowCourseForAdminViewModel> GetAllCoursesForAdmin()
        {
            return _context.Courses
                .Include(c => c.User)
                .Select(c => new ShowCourseForAdminViewModel()
                {
                    Id = c.CourseId,
                    Title = c.CourseTitle,
                    ImageName = c.CourseImageName,
                    EpisodeNumber = c.CourseEpisodes.Count,
                    TeacherName = c.User.FullName,
                    RegisterDate = c.CreateDate

                }).ToList();
        }

        public ShowCourseForAdminViewModel GetCourseByIdForAdmin(int courseId)
        {
            return _context.Courses.Where(c => c.CourseId == courseId).Include(c => c.User).Select(c => new ShowCourseForAdminViewModel()
            {
                Id = c.CourseId,
                Title = c.CourseTitle,
                ImageName = c.CourseImageName,
                RegisterDate = c.CreateDate,
                EpisodeNumber = c.CourseEpisodes.Count,
                TeacherName = c.User.FullName


            }).FirstOrDefault();
        }

        public bool DeleteCourse(int id)
        {
            try
            {
                var course = base.GetById(id);

                #region Check Exist Main Course Image  And Delete

                var mainImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses",
                    course.CourseImageName);


                if (File.Exists(mainImagePath))
                {
                    File.Delete(mainImagePath);
                }

                #endregion

                #region Check Exist Thumbnail Course Image  And Delete

                var thumbImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/Thumbnail",
                    course.CourseImageName);


                if (File.Exists(thumbImagePath))
                {
                    File.Delete(thumbImagePath);
                }

                #endregion

                #region Check Exist Demo Course Image  And Delete

                var demoImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/Courses/Demo",
                    course.DemoFileName);


                if (File.Exists(demoImagePath))
                {
                    File.Delete(demoImagePath);
                }

                #endregion

                base.Delete(id);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Tuple<List<ShowCourseListItemViewModel>, int> GetCourses(int pageId = 1, string filter = "", string getType = "all", string orderByType = "newDate",
            int minPrice = 0, int maxPrice = 0, List<int> selectedGroups = null, int take = 8)
        {


            IQueryable<DAL.Entities.Course.Course> query = _context.Courses;

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(c => c.CourseTitle.Contains(filter) || c.Tags.Contains(filter));
            }

            if (!string.IsNullOrEmpty(getType))
            {
                switch (getType)
                {
                    case "all":
                        break;

                    case "buy":
                        query = query.Where(c => c.CoursePrice > 0);
                        break;

                    case "free":
                        query = query.Where(c => c.CoursePrice == 0);
                        break;
                }
            }

            if (!string.IsNullOrEmpty(orderByType))
            {
                switch (orderByType)
                {
                    case "newDate":
                        query = query.OrderByDescending(c => c.CreateDate);
                        break;

                    case "cheep":
                        query = query.OrderByDescending(c => c.CoursePrice);
                        break;


                }
            }

            if (minPrice > 0)
            {
                query = query.Where(c => c.CoursePrice > minPrice);
            }

            if (maxPrice > 0)
            {
                query = query.Where(c => c.CoursePrice < maxPrice);
            }

            if (selectedGroups?.Any() == true)
            {
                foreach (var groupId in selectedGroups)
                {
                    query = query.Where(c => c.GroupId == groupId || c.SubGroup == groupId);
                }
            }


            var skip = (pageId - 1) * take;


            //var showCourseListItem = query.Include(c => c.CourseEpisodes)
            //    .Select(c => new ShowCourseListItemViewModel()
            //    {
            //        CourseId = c.CourseId,
            //        Title = c.CourseTitle,
            //        Price = c.CoursePrice,
            //        ImageName = c.CourseImageName,
            //        TotalTime = new TimeSpan(c.CourseEpisodes.Sum(e => e.EpisodeTime.Ticks))
            //    });


            query = query.Include(c => c.CourseEpisodes);

            var pageCount = query.Count() / take;

            var result = query.Skip(skip).Take(take).ToList();

            var listItem = result.Select(c => new ShowCourseListItemViewModel()
            {
                CourseId = c.CourseId,
                Title = c.CourseTitle,
                Price = c.CoursePrice,
                ImageName = c.CourseImageName,
                TotalTime = new TimeSpan(c.CourseEpisodes.Sum(e => e.EpisodeTime.Ticks))
            }).ToList();

            return Tuple.Create(listItem, pageCount);

        }

        public DAL.Entities.Course.Course GetCourseById(int courseId)
        {
            return _context.Courses.Include(c => c.CourseEpisodes)
                .Include(c => c.CourseStatus).Include(c => c.CourseLevel)
                .Include(c => c.User)
                .FirstOrDefault(c => c.CourseId == courseId);

        }

        public int AttendantCourseCount(int courseId)
        {
            return _context.OrderDetails.Where(c => c.CourseId == courseId)
                .ToList().Count;
        }

        public DAL.Entities.Course.Course GetCourseByShortKey(string key)
        {
            return _context.Courses.FirstOrDefault(c => c.ShortKey == key);
        }
    }
}
