using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using TopLearn.DAL.Entities;
using TopLearn.DAL.Entities.Course;
using TopLearn.DAL.Entities.Order;
using TopLearn.DAL.Entities.Permissions;

namespace TopLearn.DAL.Context
{
    public class TopLearnContext : DbContext
    {

        public TopLearnContext(DbContextOptions<TopLearnContext> options) : base(options)
        {

        }

        #region DbSet

        public DbSet<User> Users { get; set; }

        public DbSet<RoleUser> RoleUsers { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<WalletType> WalletTypes { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<CourseGroup> CourseGroups { get; set; }

        public DbSet<CourseLevel> CourseLevels { get; set; }

        public DbSet<CourseStatus> CourseStatuses { get; set; }

        public DbSet<CourseEpisode> CourseEpisodes { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        #endregion


        #region Seed data and QueryFilter 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Disable Cascade Delete

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            #endregion

            #region SeedForUser

            modelBuilder.Entity<User>().HasData(new User()
            {
                UserId = 1,
                FullName = "علی جهانگیر",
                UserName = "admin",
                Email = "iraniandeveloper.net@gmail.com",
                Mobile = "09198948580",
                IsActive = true,
                ActiveCode = "18456637",
                Password = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70",
                IsDeleted = false,
                RegisterDate = DateTime.Now,
                UserAvatar = "Default.jpg"


            });

            #endregion

            #region SeedForRole

            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleId = 1,
                RoleName = "admin",
                Description = "مدیر سایت"
            },
                new Role()
                {
                    RoleId = 2,
                    RoleName = "teacher",
                    Description = "مدرس"

                },
                new Role()
                {
                    RoleId = 3,
                    RoleName = "user",
                    Description = "کاربر عادی سایت"

                });


            #endregion

            #region SeedForRoleUser

            modelBuilder.Entity<RoleUser>().HasData(new RoleUser()
            {
                Id = 1,
                UserId = 1,
                RoleId = 1
            }, new RoleUser()
            {
                Id = 2,
                UserId = 1,
                RoleId = 2

            });

            #endregion

            #region SeedWalleType

            modelBuilder.Entity<WalletType>().HasData(new WalletType()
            {
                WalletTypeId = 1,
                Title = "deposit",
                Description = "واریز"
            },
                new WalletType()
                {
                    WalletTypeId = 2,
                    Title = "Withdraw",
                    Description = "برداشت"

                });



            #endregion

            #region SeedForPermissions

            modelBuilder.Entity<Permission>().HasData(
              new Permission()
              {
                  PermissionId = 1,
                  PermissionTitle = "پنل مدیریت",
                  ParentId = null
              }
              , new Permission()
              {
                  PermissionId = 2,
                  PermissionTitle = "مدیریت کاربران",
                  ParentId = 1
              }, new Permission()
              {
                  PermissionId = 3,
                  PermissionTitle = "افزودن کاربر",
                  ParentId = 2
              }, new Permission()
              {
                  PermissionId = 4,
                  PermissionTitle = "ویرایش کاربر",
                  ParentId = 2
              }, new Permission()
              {
                  PermissionId = 5,
                  PermissionTitle = "حذف کاربر",
                  ParentId = 2
              }, new Permission()
              {
                  PermissionId = 6,
                  PermissionTitle = "لیست کاربران حذف شده",
                  ParentId = 2
              }
              , new Permission()
              {
                  PermissionId = 7,
                  PermissionTitle = "مدیریت نقش ها",
                  ParentId = 1
              }, new Permission()
              {
                  PermissionId = 8,
                  PermissionTitle = "افزودن نقش",
                  ParentId = 7
              }, new Permission()
              {
                  PermissionId = 9,
                  PermissionTitle = "ویرایش نقش",
                  ParentId = 7
              }, new Permission()
              {
                  PermissionId = 10,
                  PermissionTitle = "حذف نقش",
                  ParentId = 7
              }, new Permission()
              {
                  PermissionId = 11,
                  PermissionTitle = "لیست نقش های حذف شده",
                  ParentId = 8
              }
              , new Permission()
              {
                  PermissionId = 12,
                  PermissionTitle = "مدیریت دسترسی ها ",
                  ParentId = 1
              }, new Permission()
              {
                  PermissionId = 13,
                  PermissionTitle = "افزودن دسترسی",
                  ParentId = 12
              }, new Permission()
              {
                  PermissionId = 14,
                  PermissionTitle = "ویرایش دسترسی",
                  ParentId = 12
              }, new Permission()
              {
                  PermissionId = 15,
                  PermissionTitle = "حذف دسترسی",
                  ParentId = 12
              }, new Permission()
              {
                  PermissionId = 16,
                  PermissionTitle = "مدیریت دوره ها",
                  ParentId = 1
              }, new Permission()
              {
                  PermissionId = 17,
                  PermissionTitle = "افزودن دوره",
                  ParentId = 16
              }, new Permission()
              {
                  PermissionId = 18,
                  PermissionTitle = "ویرایش دوره ",
                  ParentId = 16
              }, new Permission()
              {
                  PermissionId = 19,
                  PermissionTitle = "حذف دوره ",
                  ParentId = 16
              }, new Permission()
              {
                  PermissionId = 20,
                  PermissionTitle = "مدیریت جلسه ها",
                  ParentId = 1
              }, new Permission()
              {
                  PermissionId = 21,
                  PermissionTitle = "افزایش جلسه ",
                  ParentId = 20
              }, new Permission()
              {
                  PermissionId = 22,
                  PermissionTitle = "ویرایش جلسه ",
                  ParentId = 20
              }, new Permission()
              {
                  PermissionId = 23,
                  PermissionTitle = "حذف جلسه",
                  ParentId = 20
              });


            #endregion

            #region SeedForRolePermission

            modelBuilder.Entity<RolePermission>().HasData(new RolePermission()
            {
                RolePermissionId = 1,
                RoleId = 1,
                PermissionId = 1
            },
           new RolePermission()
           {
               RolePermissionId = 2,
               RoleId = 1,
               PermissionId = 2

           }
           ,
           new RolePermission()
           {
               RolePermissionId = 3,
               RoleId = 1,
               PermissionId = 3

           },
           new RolePermission()
           {
               RolePermissionId = 4,
               RoleId = 1,
               PermissionId = 4

           },
           new RolePermission()
           {
               RolePermissionId = 5,
               RoleId = 1,
               PermissionId = 5

           },
           new RolePermission()
           {
               RolePermissionId = 6,
               RoleId = 1,
               PermissionId = 6

           },
           new RolePermission()
           {
               RolePermissionId = 7,
               RoleId = 1,
               PermissionId = 7

           },
           new RolePermission()
           {
               RolePermissionId = 8,
               RoleId = 1,
               PermissionId = 8

           },
           new RolePermission()
           {
               RolePermissionId = 9,
               RoleId = 1,
               PermissionId = 9

           },
           new RolePermission()
           {
               RolePermissionId = 10,
               RoleId = 1,
               PermissionId = 10

           },
           new RolePermission()
           {
               RolePermissionId = 11,
               RoleId = 1,
               PermissionId = 11

           },
           new RolePermission()
           {
               RolePermissionId = 12,
               RoleId = 1,
               PermissionId = 12

           },
           new RolePermission()
           {
               RolePermissionId = 13,
               RoleId = 1,
               PermissionId = 13

           },
           new RolePermission()
           {
               RolePermissionId = 14,
               RoleId = 1,
               PermissionId = 14

           },
           new RolePermission()
           {
               RolePermissionId = 15,
               RoleId = 1,
               PermissionId = 15

           },
           new RolePermission()
           {
               RolePermissionId = 16,
               RoleId = 1,
               PermissionId = 16

           },
           new RolePermission()
           {
               RolePermissionId = 17,
               RoleId = 1,
               PermissionId = 17

           },
           new RolePermission()
           {
               RolePermissionId = 18,
               RoleId = 1,
               PermissionId = 18

           },
           new RolePermission()
           {
               RolePermissionId = 19,
               RoleId = 1,
               PermissionId = 19

           },
           new RolePermission()
           {
               RolePermissionId = 20,
               RoleId = 1,
               PermissionId = 20

           },
           new RolePermission()
           {
               RolePermissionId = 21,
               RoleId = 1,
               PermissionId = 21

           },
           new RolePermission()
           {
               RolePermissionId = 22,
               RoleId = 1,
               PermissionId = 22

           },
           new RolePermission()
           {
               RolePermissionId = 23,
               RoleId = 1,
               PermissionId = 23

           });


            #endregion

            #region SeedForCourseGroup

            modelBuilder.Entity<CourseGroup>().HasData(
              new CourseGroup()
              {
                  GroupId = 1,
                  GroupTitle = "برنامه نویسی موبایل",
                  ParentId = null,
                  IsDelete = false
              },
              new CourseGroup()
              {
                  GroupId = 2,
                  GroupTitle = " زامارین  Xamarin ",
                  ParentId = 1,
                  IsDelete = false
              },
              new CourseGroup()
              {
                  GroupId = 3,
                  GroupTitle = " react Native ",
                  ParentId = 1,
                  IsDelete = false
              },
              new CourseGroup()
              {
                  GroupId = 4,
                  GroupTitle = "برنامه نویسی وب",
                  ParentId = null,
                  IsDelete = false
              }
              ,
              new CourseGroup()
              {
                  GroupId = 5,
                  GroupTitle = "asp.net WebForm",
                  ParentId = 4,
                  IsDelete = false
              }
              ,
              new CourseGroup()
              {
                  GroupId = 6,
                  GroupTitle = "asp.net Mvc",
                  ParentId = 4,
                  IsDelete = false
              }
              ,
              new CourseGroup()
              {
                  GroupId = 7,
                  GroupTitle = "asp.net Core ",
                  ParentId = 4,
                  IsDelete = false
              }
              ,
              new CourseGroup()
              {
                  GroupId = 8,
                  GroupTitle = "برنامه نویسی تحت وبندوز",
                  ParentId = null,
                  IsDelete = false
              }
              ,
              new CourseGroup()
              {
                  GroupId = 9,
                  GroupTitle = "طراحی سایت ",
                  ParentId = null,
                  IsDelete = false
              },
              new CourseGroup()
              {
                  GroupId = 10,
                  GroupTitle = "Html",
                  ParentId = 9,
                  IsDelete = false
              },
              new CourseGroup()
              {
                  GroupId = 11,
                  GroupTitle = "Css",
                  ParentId = 9,
                  IsDelete = false
              });


            #endregion

            #region SeedForCourseLevel

            modelBuilder.Entity<CourseLevel>().HasData(
                new CourseLevel()
                {
                    LevelId = 1,
                    LevelTitle = "مقدماتی"
                },
                new CourseLevel()
                {
                    LevelId = 2,
                    LevelTitle = "متوسط"
                },
                new CourseLevel()
                {
                    LevelId = 3,
                    LevelTitle = "پیشرفته"
                },
                new CourseLevel()
                {
                    LevelId = 4,
                    LevelTitle = "فوق پیشرفته"
                });

            #endregion

            #region SeedForCourseStatus

            modelBuilder.Entity<CourseStatus>().HasData(
                new CourseStatus()
                {
                    StatusId = 1,
                    StatusTitle = "درحال برگزاری دوره"
                },
                new CourseStatus()
                {
                    StatusId = 2,
                    StatusTitle = "اتمام دوره"
                },
                new CourseStatus()
                {
                    StatusId = 3,
                    StatusTitle = "توقف دوره"
                });

            #endregion


            #region QueryFilter 

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDeleted);

            modelBuilder.Entity<Permission>().HasQueryFilter(p => !p.IsDeleted);


            #endregion




            base.OnModelCreating(modelBuilder);

        }

        #endregion
    }
}
