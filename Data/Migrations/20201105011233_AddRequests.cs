using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06da996e-999c-411f-ba17-b9782ee1dea3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402f9b8b-2568-4fa9-b473-d5a69e9bef40");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3c378a01-65dd-40dd-9280-ef1d06d2d453", "3c378a01-65dd-40dd-9280-ef1d06d2d453" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c378a01-65dd-40dd-9280-ef1d06d2d453");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c378a01-65dd-40dd-9280-ef1d06d2d453");

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ThesisId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Requests_Theses_ThesisId",
                        column: x => x.ThesisId,
                        principalTable: "Theses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "332b9243-01a6-4876-8452-9468528ccc06", "8fd5ee71-dea6-4de3-9484-a692a8b14f99", "Student", "STUDENT" },
                    { "476bd608-8ee8-410a-a470-9fce574a6112", "ecf9ea93-da58-46e5-91b6-8a080a29e104", "Admin", "ADMIN" },
                    { "9bd53dcf-4bb8-4946-9d16-98ce31a0d87e", "ab44cf76-5cae-4417-8b95-122183f52981", "Professor", "PROFESSOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "476bd608-8ee8-410a-a470-9fce574a6112", 0, "f4da889c-e889-4de0-a3d7-8c71d166e6a2", "admin@admin.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAENBHXnBbVFwbYOdJ21AdfOXZIbJQl7Mam7cUeB5B7067GOA33glIcUbh2scQYsBGbQ==", null, false, null, "af08c99a-eb49-4760-9af1-447df7911bfa", false, "admin@admin.com", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "476bd608-8ee8-410a-a470-9fce574a6112", "476bd608-8ee8-410a-a470-9fce574a6112" });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentId",
                table: "Requests",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ThesisId",
                table: "Requests",
                column: "ThesisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332b9243-01a6-4876-8452-9468528ccc06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bd53dcf-4bb8-4946-9d16-98ce31a0d87e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "476bd608-8ee8-410a-a470-9fce574a6112", "476bd608-8ee8-410a-a470-9fce574a6112" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "476bd608-8ee8-410a-a470-9fce574a6112");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "476bd608-8ee8-410a-a470-9fce574a6112");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06da996e-999c-411f-ba17-b9782ee1dea3", "1aa2d3a0-d2e7-492f-8a5d-88d827b1ffb8", "Student", "STUDENT" },
                    { "3c378a01-65dd-40dd-9280-ef1d06d2d453", "71c8b06c-49c4-4416-8f37-9802e0422609", "Admin", "ADMIN" },
                    { "402f9b8b-2568-4fa9-b473-d5a69e9bef40", "c60e8607-b614-4f18-b2aa-4398f3ce436f", "Professor", "PROFESSOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "3c378a01-65dd-40dd-9280-ef1d06d2d453", 0, "47fb756c-2d73-4839-b4a0-f9de72b9c69a", "admin@admin.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAgHJ3shsjf8rtbNQNfcfjVt5CXj0ZCqcW69nv9mEiu+ks49Vu4TmJ+Od6e90W0VSw==", null, false, null, "f19a2ddb-6783-481f-8cb4-67d2d11e6b8d", false, "admin@admin.com", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3c378a01-65dd-40dd-9280-ef1d06d2d453", "3c378a01-65dd-40dd-9280-ef1d06d2d453" });
        }
    }
}
