﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopLearn.DAL.Context;

namespace TopLearn.DAL.Migrations
{
    [DbContext(typeof(TopLearnContext))]
    [Migration("20201120145838_Add Seed For CourseLevel And CourseStatuse ")]
    partial class AddSeedForCourseLevelAndCourseStatuse
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TopLearn.DAL.Entities.Course.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseImageName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("CourseLevelLevelId")
                        .HasColumnType("int");

                    b.Property<int>("CoursePrice")
                        .HasColumnType("int");

                    b.Property<int?>("CourseStatusStatusId")
                        .HasColumnType("int");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasMaxLength(450);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DemoFileName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("SubGroup")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(600)")
                        .HasMaxLength(600);

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CourseId");

                    b.HasIndex("CourseLevelLevelId");

                    b.HasIndex("CourseStatusStatusId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SubGroup");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Course.CourseEpisode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("EpisodeFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("EpisodeTime")
                        .HasColumnType("time");

                    b.Property<string>("EpisodeTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.HasKey("EpisodeId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseEpisodes");
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Course.CourseGroup", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("GroupId");

                    b.HasIndex("ParentId");

                    b.ToTable("CourseGroups");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            GroupTitle = "برنامه نویسی موبایل",
                            IsDelete = false
                        },
                        new
                        {
                            GroupId = 2,
                            GroupTitle = " زامارین  Xamarin ",
                            IsDelete = false,
                            ParentId = 1
                        },
                        new
                        {
                            GroupId = 3,
                            GroupTitle = " react Native ",
                            IsDelete = false,
                            ParentId = 1
                        },
                        new
                        {
                            GroupId = 4,
                            GroupTitle = "برنامه نویسی وب",
                            IsDelete = false
                        },
                        new
                        {
                            GroupId = 5,
                            GroupTitle = "asp.net WebForm",
                            IsDelete = false,
                            ParentId = 4
                        },
                        new
                        {
                            GroupId = 6,
                            GroupTitle = "asp.net Mvc",
                            IsDelete = false,
                            ParentId = 4
                        },
                        new
                        {
                            GroupId = 7,
                            GroupTitle = "asp.net Core ",
                            IsDelete = false,
                            ParentId = 4
                        },
                        new
                        {
                            GroupId = 8,
                            GroupTitle = "برنامه نویسی تحت وبندوز",
                            IsDelete = false
                        },
                        new
                        {
                            GroupId = 9,
                            GroupTitle = "طراحی سایت ",
                            IsDelete = false
                        },
                        new
                        {
                            GroupId = 10,
                            GroupTitle = "Html",
                            IsDelete = false,
                            ParentId = 9
                        },
                        new
                        {
                            GroupId = 11,
                            GroupTitle = "Css",
                            IsDelete = false,
                            ParentId = 9
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Course.CourseLevel", b =>
                {
                    b.Property<int>("LevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LevelTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("LevelId");

                    b.ToTable("CourseLevels");

                    b.HasData(
                        new
                        {
                            LevelId = 1,
                            LevelTitle = "مقدماتی"
                        },
                        new
                        {
                            LevelId = 2,
                            LevelTitle = "متوسط"
                        },
                        new
                        {
                            LevelId = 3,
                            LevelTitle = "پیشرفته"
                        },
                        new
                        {
                            LevelId = 4,
                            LevelTitle = "فوق پیشرفته"
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Course.CourseStatus", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("StatusId");

                    b.ToTable("CourseStatuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            StatusTitle = "درحال برگزاری دوره"
                        },
                        new
                        {
                            StatusId = 2,
                            StatusTitle = "اتمام دوره"
                        },
                        new
                        {
                            StatusId = 3,
                            StatusTitle = "توقف دوره"
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Permissions.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentId");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            IsDeleted = false,
                            PermissionTitle = "پنل مدیریت"
                        },
                        new
                        {
                            PermissionId = 2,
                            IsDeleted = false,
                            ParentId = 1,
                            PermissionTitle = "مدیریت کاربران"
                        },
                        new
                        {
                            PermissionId = 3,
                            IsDeleted = false,
                            ParentId = 2,
                            PermissionTitle = "افزودن کاربر"
                        },
                        new
                        {
                            PermissionId = 4,
                            IsDeleted = false,
                            ParentId = 2,
                            PermissionTitle = "ویرایش کاربر"
                        },
                        new
                        {
                            PermissionId = 5,
                            IsDeleted = false,
                            ParentId = 2,
                            PermissionTitle = "حذف کاربر"
                        },
                        new
                        {
                            PermissionId = 6,
                            IsDeleted = false,
                            ParentId = 2,
                            PermissionTitle = "لیست کاربران حذف شده"
                        },
                        new
                        {
                            PermissionId = 7,
                            IsDeleted = false,
                            ParentId = 1,
                            PermissionTitle = "مدیریت نقش ها"
                        },
                        new
                        {
                            PermissionId = 8,
                            IsDeleted = false,
                            ParentId = 7,
                            PermissionTitle = "افزودن نقش"
                        },
                        new
                        {
                            PermissionId = 9,
                            IsDeleted = false,
                            ParentId = 7,
                            PermissionTitle = "ویرایش نقش"
                        },
                        new
                        {
                            PermissionId = 10,
                            IsDeleted = false,
                            ParentId = 7,
                            PermissionTitle = "حذف نقش"
                        },
                        new
                        {
                            PermissionId = 11,
                            IsDeleted = false,
                            ParentId = 8,
                            PermissionTitle = "لیست نقش های حذف شده"
                        },
                        new
                        {
                            PermissionId = 12,
                            IsDeleted = false,
                            ParentId = 1,
                            PermissionTitle = "مدیریت دسترسی ها "
                        },
                        new
                        {
                            PermissionId = 13,
                            IsDeleted = false,
                            ParentId = 12,
                            PermissionTitle = "افزودن دسترسی"
                        },
                        new
                        {
                            PermissionId = 14,
                            IsDeleted = false,
                            ParentId = 12,
                            PermissionTitle = "ویرایش دسترسی"
                        },
                        new
                        {
                            PermissionId = 15,
                            IsDeleted = false,
                            ParentId = 12,
                            PermissionTitle = "حذف دسترسی"
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Permissions.RolePermission", b =>
                {
                    b.Property<int>("RolePermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RolePermissionId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            RolePermissionId = 1,
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 2,
                            PermissionId = 2,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 3,
                            PermissionId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 4,
                            PermissionId = 4,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 5,
                            PermissionId = 5,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 6,
                            PermissionId = 6,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 7,
                            PermissionId = 7,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 8,
                            PermissionId = 8,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 9,
                            PermissionId = 9,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 10,
                            PermissionId = 10,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 11,
                            PermissionId = 11,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 12,
                            PermissionId = 12,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 13,
                            PermissionId = 13,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 14,
                            PermissionId = 14,
                            RoleId = 1
                        },
                        new
                        {
                            RolePermissionId = 15,
                            PermissionId = 15,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Description = "مدیر سایت",
                            IsDeleted = false,
                            RoleName = "admin"
                        },
                        new
                        {
                            RoleId = 2,
                            Description = "کاربر عادی سایت",
                            IsDeleted = false,
                            RoleName = "user"
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.RoleUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("RoleUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserAvatar")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ActiveCode = "18456637",
                            Email = "iraniandeveloper.net@gmail.com",
                            FullName = "علی جهانگیر",
                            IsActive = true,
                            IsDeleted = false,
                            Mobile = "09198948580",
                            Password = "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70",
                            RegisterDate = new DateTime(2020, 11, 20, 18, 28, 37, 693, DateTimeKind.Local).AddTicks(319),
                            UserAvatar = "Default.jpg",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("IsPay")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WalletTypeId")
                        .HasColumnType("int");

                    b.HasKey("WalletId");

                    b.HasIndex("UserId");

                    b.HasIndex("WalletTypeId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.WalletType", b =>
                {
                    b.Property<int>("WalletTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("WalletTypeId");

                    b.ToTable("WalletTypes");

                    b.HasData(
                        new
                        {
                            WalletTypeId = 1,
                            Description = "واریز",
                            Title = "deposit"
                        },
                        new
                        {
                            WalletTypeId = 2,
                            Description = "برداشت",
                            Title = "Withdraw"
                        });
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Course.Course", b =>
                {
                    b.HasOne("TopLearn.DAL.Entities.Course.CourseLevel", "CourseLevel")
                        .WithMany("Courses")
                        .HasForeignKey("CourseLevelLevelId");

                    b.HasOne("TopLearn.DAL.Entities.Course.CourseStatus", "CourseStatus")
                        .WithMany("Courses")
                        .HasForeignKey("CourseStatusStatusId");

                    b.HasOne("TopLearn.DAL.Entities.Course.CourseGroup", "CourseGroup")
                        .WithMany("Courses")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DAL.Entities.Course.CourseGroup", "SubCourseGroup")
                        .WithMany("SubGroup")
                        .HasForeignKey("SubGroup");

                    b.HasOne("TopLearn.DAL.Entities.User", "User")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Course.CourseEpisode", b =>
                {
                    b.HasOne("TopLearn.DAL.Entities.Course.Course", "Course")
                        .WithMany("CourseEpisodes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Course.CourseGroup", b =>
                {
                    b.HasOne("TopLearn.DAL.Entities.Course.CourseGroup", null)
                        .WithMany("CourseGroups")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Permissions.Permission", b =>
                {
                    b.HasOne("TopLearn.DAL.Entities.Permissions.Permission", null)
                        .WithMany("Permissions")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Permissions.RolePermission", b =>
                {
                    b.HasOne("TopLearn.DAL.Entities.Permissions.Permission", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DAL.Entities.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.RoleUser", b =>
                {
                    b.HasOne("TopLearn.DAL.Entities.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DAL.Entities.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopLearn.DAL.Entities.Wallet", b =>
                {
                    b.HasOne("TopLearn.DAL.Entities.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TopLearn.DAL.Entities.WalletType", "WalletType")
                        .WithMany("Wallets")
                        .HasForeignKey("WalletTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
