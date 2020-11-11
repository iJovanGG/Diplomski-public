using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddCommentToThesis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThesisId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Posted = table.Column<DateTime>(nullable: false),
                    Message = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Theses_ThesisId",
                        column: x => x.ThesisId,
                        principalTable: "Theses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac98b934-139a-4664-a9ac-663f7c8eb6fd", "5229f310-d772-4be3-8c8e-72bb14c2cd2b", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9406789f-c2ec-4d13-9d27-5668c039cc4e", "8e243cc7-d8aa-4e7e-b4f0-e53fe4c5fe87", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "407d8c85-c490-416f-8a7e-0aebe989d8e7", "64554edf-e173-46ff-a14a-56e6718d143c", "Professor", "PROFESSOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ThesisId",
                table: "Comments",
                column: "ThesisId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "407d8c85-c490-416f-8a7e-0aebe989d8e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9406789f-c2ec-4d13-9d27-5668c039cc4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac98b934-139a-4664-a9ac-663f7c8eb6fd");

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
    }
}
