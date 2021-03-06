﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedRolesToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46e8f39b-8397-4132-bfc1-e73c395246a4", "54114d2f-e23c-461e-9e0f-bf96099d1e99", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "28b04c0f-faee-4907-8b38-eecd6569d744", "1fc024cf-bfa8-44b7-bc52-7b754ff4490d", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b4d3a900-1e27-4842-8907-e29a098325a8", "ee5be1a2-682a-4d76-87a8-ed139dabf464", "Proffesor", "PROFFESOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28b04c0f-faee-4907-8b38-eecd6569d744");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e8f39b-8397-4132-bfc1-e73c395246a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4d3a900-1e27-4842-8907-e29a098325a8");
        }
    }
}
