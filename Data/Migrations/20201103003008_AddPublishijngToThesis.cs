using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddPublishijngToThesis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                table: "Theses",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "38b98e38-5211-420c-b98a-0b5404396837", "01f85841-d8b5-4fd8-a813-22b539f2defd", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88eb4375-2ad8-46bf-a7fb-c8baed057483", "bb9a66c5-129e-469c-a839-dd35ab760713", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9a84d84f-01b9-456b-9b91-66b9ee23b489", "59b22a3f-f978-4dc0-addc-67309a872dde", "Professor", "PROFESSOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "38b98e38-5211-420c-b98a-0b5404396837");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88eb4375-2ad8-46bf-a7fb-c8baed057483");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a84d84f-01b9-456b-9b91-66b9ee23b489");

            migrationBuilder.DropColumn(
                name: "DatePublished",
                table: "Theses");

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
        }
    }
}
