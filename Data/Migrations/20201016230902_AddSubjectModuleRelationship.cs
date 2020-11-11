using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddSubjectModuleRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Modules_ModuleRefId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_ModuleRefId",
                table: "Subjects");

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

            migrationBuilder.DropColumn(
                name: "ModuleRefId",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "ModuleId",
                table: "Subjects",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ModuleId",
                table: "Subjects",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Modules_ModuleId",
                table: "Subjects",
                column: "ModuleId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Modules_ModuleId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_ModuleId",
                table: "Subjects");

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

            migrationBuilder.DropColumn(
                name: "ModuleId",
                table: "Subjects");

            migrationBuilder.AddColumn<int>(
                name: "ModuleRefId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4a1fd95-e0da-4e97-96fe-4837dfe4ecb0", "9b988d1a-0543-4520-8d0a-e22f1287ba27", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1c9fe7e-ca61-493f-b6a6-37699690aff2", "2dc2ca75-869e-4ec5-8ca2-b74346e925cf", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5ea128c5-d8e1-4ade-b5ed-3e20af027811", "76c3bd5a-b8e5-4c83-a20c-7d99b0b23734", "Proffesor", "PROFFESOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_ModuleRefId",
                table: "Subjects",
                column: "ModuleRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Modules_ModuleRefId",
                table: "Subjects",
                column: "ModuleRefId",
                principalTable: "Modules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
