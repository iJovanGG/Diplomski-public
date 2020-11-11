using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddSubjectsAndFacultyModules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleRefId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Modules_ModuleRefId",
                        column: x => x.ModuleRefId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessorSubjects",
                columns: table => new
                {
                    ProfessorId = table.Column<string>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorSubjects", x => new { x.ProfessorId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_ProfessorSubjects_AspNetUsers_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessorSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a4a1fd95-e0da-4e97-96fe-4837dfe4ecb0", "9b988d1a-0543-4520-8d0a-e22f1287ba27", "Student", "STUDENT" },
                    { "c1c9fe7e-ca61-493f-b6a6-37699690aff2", "2dc2ca75-869e-4ec5-8ca2-b74346e925cf", "Admin", "ADMIN " },
                    { "5ea128c5-d8e1-4ade-b5ed-3e20af027811", "76c3bd5a-b8e5-4c83-a20c-7d99b0b23734", "Proffesor", "PROFFESOR" }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Elektroenergetika" },
                    { 2, "Elektrotehnika i računarstvo" },
                    { 3, "Elektronika" },
                    { 4, "Elektronske komponente i mikrosistemi" },
                    { 5, "Upravljanje sistemima" },
                    { 6, "Komunikacije i informacione tehnologije" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorSubjects_SubjectId",
                table: "ProfessorSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ModuleRefId",
                table: "Subjects",
                column: "ModuleRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorSubjects");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ea128c5-d8e1-4ade-b5ed-3e20af027811");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4a1fd95-e0da-4e97-96fe-4837dfe4ecb0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1c9fe7e-ca61-493f-b6a6-37699690aff2");

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
    }
}
