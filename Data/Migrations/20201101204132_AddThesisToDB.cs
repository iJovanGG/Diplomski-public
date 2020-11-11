using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddThesisToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Theses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    DateTaken = table.Column<DateTime>(nullable: true),
                    ProfessorId = table.Column<string>(nullable: true),
                    TakenByStudentId = table.Column<string>(nullable: true),
                    SubjectId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 128, nullable: true),
                    ShortDescription = table.Column<string>(maxLength: 300, nullable: true),
                    Discription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Theses_AspNetUsers_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Theses_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Theses_AspNetUsers_TakenByStudentId",
                        column: x => x.TakenByStudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_Name",
                table: "Subjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Theses_ProfessorId",
                table: "Theses",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_SubjectId",
                table: "Theses",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_TakenByStudentId",
                table: "Theses",
                column: "TakenByStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Theses");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_Name",
                table: "Subjects");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

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
    }
}
