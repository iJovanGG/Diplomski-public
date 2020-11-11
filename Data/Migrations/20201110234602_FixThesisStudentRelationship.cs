using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FixThesisStudentRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theses_AspNetUsers_TakenByStudentId",
                table: "Theses");

            migrationBuilder.DropIndex(
                name: "IX_Theses_TakenByStudentId",
                table: "Theses");

            migrationBuilder.DropIndex(
                name: "IX_Requests_StudentId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "TakenByStudentId",
                table: "Theses");

            migrationBuilder.AddColumn<int>(
                name: "AsignedThesisId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332b9243-01a6-4876-8452-9468528ccc06",
                column: "ConcurrencyStamp",
                value: "79165e87-9b2d-4ac1-8918-ca6c2c88a31d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "476bd608-8ee8-410a-a470-9fce574a6112",
                column: "ConcurrencyStamp",
                value: "b032a703-3c2a-4111-a111-e33b60b9fdbc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bd53dcf-4bb8-4946-9d16-98ce31a0d87e",
                column: "ConcurrencyStamp",
                value: "e94db597-87e8-4ff0-ab32-4d56861b5ecb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "476bd608-8ee8-410a-a470-9fce574a6112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "299655f8-e2de-4786-bbc3-ba9b2985e50e", "AQAAAAEAACcQAAAAEG8T68k6SPWbt3GVCbVMV54ZL4/qvXYiKwxNrVgJrKSiK0VNtqWeypyynyuvTRPSug==", "b25e49ee-e8be-4013-b1d0-c1abae83a775" });

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentId",
                table: "Requests",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AsignedThesisId",
                table: "AspNetUsers",
                column: "AsignedThesisId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Theses_AsignedThesisId",
                table: "AspNetUsers",
                column: "AsignedThesisId",
                principalTable: "Theses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Theses_AsignedThesisId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Requests_StudentId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AsignedThesisId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AsignedThesisId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "TakenByStudentId",
                table: "Theses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332b9243-01a6-4876-8452-9468528ccc06",
                column: "ConcurrencyStamp",
                value: "99255a77-50db-4010-964b-85d0eb068e47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "476bd608-8ee8-410a-a470-9fce574a6112",
                column: "ConcurrencyStamp",
                value: "a9497cb2-0737-4484-96f8-e424eb1d06b4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bd53dcf-4bb8-4946-9d16-98ce31a0d87e",
                column: "ConcurrencyStamp",
                value: "04b7aee6-a760-44d0-89cf-525e1d65106f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "476bd608-8ee8-410a-a470-9fce574a6112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26cc8ce0-127a-42ac-9788-bfc3e74aaac7", "AQAAAAEAACcQAAAAEL1BvyAxNdf+eiSu2Lz25ghr8llt6lugYWYPbJn1Eq2WXj3BnUENgtnpeOsdUCd4Gw==", "8d911ea2-3262-4f7a-9f0e-60c0948a30cc" });

            migrationBuilder.CreateIndex(
                name: "IX_Theses_TakenByStudentId",
                table: "Theses",
                column: "TakenByStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_StudentId",
                table: "Requests",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_AspNetUsers_TakenByStudentId",
                table: "Theses",
                column: "TakenByStudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
