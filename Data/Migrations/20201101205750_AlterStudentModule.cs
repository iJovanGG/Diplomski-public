using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AlterStudentModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17d9fec6-64e6-42d3-97cf-681a12fa8a06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f8478b2-8f72-4919-8cab-8729a27a8591");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4861793-ff88-41d2-9b34-1bbf520be8f8");

            migrationBuilder.DropColumn(
                name: "Module",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3d7eef77-11db-4f34-8021-44b0d5e7a1c8", "3298d287-532a-4e38-b986-edeaf6c6efa4", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4b7e96b6-851c-404a-a26d-919406064de1", "cf9d6541-8a44-45ec-91a2-b8720acaed86", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "522f8b17-8edd-4e08-b8e0-04511bc0633b", "805608d6-2d3c-468b-8762-28fe15e2cc10", "Professor", "PROFESSOR" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ModuleId",
                table: "AspNetUsers",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Modules_ModuleId",
                table: "AspNetUsers",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Modules_ModuleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ModuleId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d7eef77-11db-4f34-8021-44b0d5e7a1c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b7e96b6-851c-404a-a26d-919406064de1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "522f8b17-8edd-4e08-b8e0-04511bc0633b");

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Module",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4861793-ff88-41d2-9b34-1bbf520be8f8", "005a7990-2f3b-455d-b328-4bf0cdee6b32", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f8478b2-8f72-4919-8cab-8729a27a8591", "2fec1154-9c20-442c-9910-02baaadd9694", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17d9fec6-64e6-42d3-97cf-681a12fa8a06", "de213eba-9c5b-4782-807c-737bb699394a", "Professor", "PROFESSOR" });
        }
    }
}
