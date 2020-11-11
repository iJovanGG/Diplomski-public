using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class RemoveDefaultsForThesis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Theses",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "287d2aeb-fd9f-4ed3-8397-5afae9c0e324", "8926ac46-2444-4bc6-80d9-f104ecb329c8", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8668eb4-cc0e-4016-a382-5cd752fa2428", "7c0764ee-a64f-4135-ad6a-72ced8808a92", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b36576f-bc38-40b4-99d7-fd31ea2bee04", "67273673-31c4-45e4-a6be-97f773fc36d0", "Professor", "PROFESSOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "287d2aeb-fd9f-4ed3-8397-5afae9c0e324");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b36576f-bc38-40b4-99d7-fd31ea2bee04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8668eb4-cc0e-4016-a382-5cd752fa2428");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Theses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

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
    }
}
