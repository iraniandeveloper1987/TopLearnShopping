using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DAL.Migrations
{
    public partial class AddSeedForCourseLevelAndCourseStatuse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseLevels",
                columns: new[] { "LevelId", "LevelTitle" },
                values: new object[,]
                {
                    { 1, "مقدماتی" },
                    { 2, "متوسط" },
                    { 3, "پیشرفته" },
                    { 4, "فوق پیشرفته" }
                });

            migrationBuilder.InsertData(
                table: "CourseStatuses",
                columns: new[] { "StatusId", "StatusTitle" },
                values: new object[,]
                {
                    { 1, "درحال برگزاری دوره" },
                    { 2, "اتمام دوره" },
                    { 3, "توقف دوره" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2020, 11, 20, 18, 28, 37, 693, DateTimeKind.Local).AddTicks(319));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseLevels",
                keyColumn: "LevelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseLevels",
                keyColumn: "LevelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseLevels",
                keyColumn: "LevelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CourseLevels",
                keyColumn: "LevelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseStatuses",
                keyColumn: "StatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseStatuses",
                keyColumn: "StatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseStatuses",
                keyColumn: "StatusId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2020, 11, 20, 18, 19, 31, 308, DateTimeKind.Local).AddTicks(4820));
        }
    }
}
