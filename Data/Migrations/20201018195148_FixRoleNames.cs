using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FixRoleNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7207d465-ee92-463d-acc5-5ed3551fc1f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7da1838-6e00-411d-aa94-8f999ac37924");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e982fc62-16dc-4954-a89d-2a56f8be1626");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "172e30fb-06e8-489a-b2e3-469a219216ea", "ca8ac630-ff39-4e2e-b842-6872c7394bd6", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58718414-b070-4bd6-a49e-5835e5901df2", "361f5409-bb9d-4aea-a0dc-200bfd5383d7", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0bd079a5-1e1e-4ffa-8f80-0ac8da557f16", "1ef49758-bd15-4d95-882d-28056c35ffaa", "Professor", "PROFESSOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bd079a5-1e1e-4ffa-8f80-0ac8da557f16");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "172e30fb-06e8-489a-b2e3-469a219216ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58718414-b070-4bd6-a49e-5835e5901df2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e982fc62-16dc-4954-a89d-2a56f8be1626", "2228ce20-c0ea-45c0-921c-5b3cacddcd20", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7207d465-ee92-463d-acc5-5ed3551fc1f8", "4ac2a2c2-c04c-497a-8b98-b83673be592a", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7da1838-6e00-411d-aa94-8f999ac37924", "7b825dd7-a351-4e51-8b59-3263dbd7a5bd", "Proffesor", "PROFFESOR" });
        }
    }
}
