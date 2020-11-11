using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddProfileImagesToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "332b9243-01a6-4876-8452-9468528ccc06", "9bc717c8-cd6c-4b15-9113-2cb41a5eb022", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "476bd608-8ee8-410a-a470-9fce574a6112", "0df4b69b-714b-40a7-a78c-a90c27a6b40f", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9bd53dcf-4bb8-4946-9d16-98ce31a0d87e", "046cf462-aa38-43e1-81b1-fb65556bdd5c", "Proffesor", "PROFFESOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332b9243-01a6-4876-8452-9468528ccc06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "476bd608-8ee8-410a-a470-9fce574a6112");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bd53dcf-4bb8-4946-9d16-98ce31a0d87e");

            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "AspNetUsers");

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
    }
}
