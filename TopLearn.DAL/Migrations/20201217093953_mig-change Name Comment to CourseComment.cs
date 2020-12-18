using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DAL.Migrations
{
    public partial class migchangeNameCommenttoCourseComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentParentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Courses_CourseId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "CourseComments");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "CourseComments",
                newName: "IX_CourseComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CourseId",
                table: "CourseComments",
                newName: "IX_CourseComments_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_CommentParentId",
                table: "CourseComments",
                newName: "IX_CourseComments_CommentParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseComments",
                table: "CourseComments",
                column: "CourseCommentId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2020, 12, 17, 13, 9, 52, 391, DateTimeKind.Local).AddTicks(8016));

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_CourseComments_CommentParentId",
                table: "CourseComments",
                column: "CommentParentId",
                principalTable: "CourseComments",
                principalColumn: "CourseCommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_Courses_CourseId",
                table: "CourseComments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseComments_Users_UserId",
                table: "CourseComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_CourseComments_CommentParentId",
                table: "CourseComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_Courses_CourseId",
                table: "CourseComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseComments_Users_UserId",
                table: "CourseComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseComments",
                table: "CourseComments");

            migrationBuilder.RenameTable(
                name: "CourseComments",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComments_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComments_CourseId",
                table: "Comments",
                newName: "IX_Comments_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseComments_CommentParentId",
                table: "Comments",
                newName: "IX_Comments_CommentParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "CourseCommentId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2020, 12, 17, 13, 7, 5, 563, DateTimeKind.Local).AddTicks(5294));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentParentId",
                table: "Comments",
                column: "CommentParentId",
                principalTable: "Comments",
                principalColumn: "CourseCommentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Courses_CourseId",
                table: "Comments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
