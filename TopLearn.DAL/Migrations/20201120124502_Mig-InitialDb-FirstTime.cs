using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TopLearn.DAL.Migrations
{
    public partial class MigInitialDbFirstTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_CourseGroups_CourseGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CourseGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionTitle = table.Column<string>(maxLength: 100, nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_Permissions_Permissions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(maxLength: 11, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    ActiveCode = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    UserAvatar = table.Column<string>(maxLength: 200, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WalletTypes",
                columns: table => new
                {
                    WalletTypeId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletTypes", x => x.WalletTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RolePermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.RolePermissionId);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    IsPay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                    table.ForeignKey(
                        name: "FK_Wallets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wallets_WalletTypes_WalletTypeId",
                        column: x => x.WalletTypeId,
                        principalTable: "WalletTypes",
                        principalColumn: "WalletTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseGroups",
                columns: new[] { "GroupId", "GroupTitle", "IsDelete", "ParentId" },
                values: new object[,]
                {
                    { 1, "برنامه نویسی موبایل", false, null },
                    { 4, "برنامه نویسی وب", false, null },
                    { 8, "برنامه نویسی تحت وبندوز", false, null },
                    { 9, "طراحی سایت ", false, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "IsDeleted", "ParentId", "PermissionTitle" },
                values: new object[] { 1, false, null, "پنل مدیریت" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Description", "IsDeleted", "RoleName" },
                values: new object[,]
                {
                    { 1, "مدیر سایت", false, "admin" },
                    { 2, "کاربر عادی سایت", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "ActiveCode", "Email", "FullName", "IsActive", "IsDeleted", "Mobile", "Password", "RegisterDate", "UserAvatar", "UserName" },
                values: new object[] { 1, "18456637", "iraniandeveloper.net@gmail.com", "علی جهانگیر", true, false, "09198948580", "20-2C-B9-62-AC-59-07-5B-96-4B-07-15-2D-23-4B-70", new DateTime(2020, 11, 20, 16, 15, 1, 905, DateTimeKind.Local).AddTicks(4459), "Default.jpg", "admin" });

            migrationBuilder.InsertData(
                table: "WalletTypes",
                columns: new[] { "WalletTypeId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "واریز", "deposit" },
                    { 2, "برداشت", "Withdraw" }
                });

            migrationBuilder.InsertData(
                table: "CourseGroups",
                columns: new[] { "GroupId", "GroupTitle", "IsDelete", "ParentId" },
                values: new object[,]
                {
                    { 2, " زامارین  Xamarin ", false, 1 },
                    { 3, " react Native ", false, 1 },
                    { 5, "asp.net WebForm", false, 4 },
                    { 6, "asp.net Mvc", false, 4 },
                    { 7, "asp.net Core ", false, 4 },
                    { 10, "Html", false, 9 },
                    { 11, "Css", false, 9 }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "IsDeleted", "ParentId", "PermissionTitle" },
                values: new object[,]
                {
                    { 2, false, 1, "مدیریت کاربران" },
                    { 7, false, 1, "مدیریت نقش ها" },
                    { 12, false, 1, "مدیریت دسترسی ها " }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "RoleUsers",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "IsDeleted", "ParentId", "PermissionTitle" },
                values: new object[,]
                {
                    { 3, false, 2, "افزودن کاربر" },
                    { 4, false, 2, "ویرایش کاربر" },
                    { 5, false, 2, "حذف کاربر" },
                    { 6, false, 2, "لیست کاربران حذف شده" },
                    { 8, false, 7, "افزودن نقش" },
                    { 9, false, 7, "ویرایش نقش" },
                    { 10, false, 7, "حذف نقش" },
                    { 13, false, 12, "افزودن دسترسی" },
                    { 14, false, 12, "ویرایش دسترسی" },
                    { 15, false, 12, "حذف دسترسی" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 2, 2, 1 },
                    { 7, 7, 1 },
                    { 12, 12, 1 }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "IsDeleted", "ParentId", "PermissionTitle" },
                values: new object[] { 11, false, 8, "لیست نقش های حذف شده" });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 8, 8, 1 },
                    { 9, 9, 1 },
                    { 10, 10, 1 },
                    { 13, 13, 1 },
                    { 14, 14, 1 },
                    { 15, 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "RolePermissionId", "PermissionId", "RoleId" },
                values: new object[] { 11, 11, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_CourseGroups_ParentId",
                table: "CourseGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ParentId",
                table: "Permissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_RoleId",
                table: "RoleUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_UserId",
                table: "RoleUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_UserId",
                table: "Wallets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallets_WalletTypeId",
                table: "Wallets",
                column: "WalletTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseGroups");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "RoleUsers");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WalletTypes");
        }
    }
}
