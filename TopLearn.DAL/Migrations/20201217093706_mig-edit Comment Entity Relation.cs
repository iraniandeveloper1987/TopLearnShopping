using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DAL.Migrations
{
    public partial class migeditCommentEntityRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2020, 12, 17, 13, 7, 5, 563, DateTimeKind.Local).AddTicks(5294));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RegisterDate",
                value: new DateTime(2020, 12, 17, 13, 2, 57, 873, DateTimeKind.Local).AddTicks(6476));
        }
    }
}
