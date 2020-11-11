using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class SeedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "55e556f0-703a-4853-b6d3-b3971e30bb25", "6974a4cf-cd0e-4b7c-a613-c1906c096747" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55e556f0-703a-4853-b6d3-b3971e30bb25");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06da996e-999c-411f-ba17-b9782ee1dea3", "1aa2d3a0-d2e7-492f-8a5d-88d827b1ffb8", "Student", "STUDENT" },
                    { "3c378a01-65dd-40dd-9280-ef1d06d2d453", "71c8b06c-49c4-4416-8f37-9802e0422609", "Admin", "ADMIN" },
                    { "402f9b8b-2568-4fa9-b473-d5a69e9bef40", "c60e8607-b614-4f18-b2aa-4398f3ce436f", "Professor", "PROFESSOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "3c378a01-65dd-40dd-9280-ef1d06d2d453", 0, "47fb756c-2d73-4839-b4a0-f9de72b9c69a", "admin@admin.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAgHJ3shsjf8rtbNQNfcfjVt5CXj0ZCqcW69nv9mEiu+ks49Vu4TmJ+Od6e90W0VSw==", null, false, null, "f19a2ddb-6783-481f-8cb4-67d2d11e6b8d", false, "admin@admin.com", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "3c378a01-65dd-40dd-9280-ef1d06d2d453", "3c378a01-65dd-40dd-9280-ef1d06d2d453" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "3c378a01-65dd-40dd-9280-ef1d06d2d453", "3c378a01-65dd-40dd-9280-ef1d06d2d453" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "407d8c85-c490-416f-8a7e-0aebe989d8e7", "8926ac46-2444-4bc6-80d9-f104ecb329c8", "Student", "STUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac98b934-139a-4664-a9ac-663f7c8eb6fd", "7c0764ee-a64f-4135-ad6a-72ced8808a92", "Admin", "ADMIN " });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b36576f-bc38-40b4-99d7-fd31ea2bee04", "67273673-31c4-45e4-a6be-97f773fc36d0", "Professor", "PROFESSOR" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c378a01-65dd-40dd-9280-ef1d06d2d453");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "55e556f0-703a-4853-b6d3-b3971e30bb25", "ba9c8531-a114-4e6c-a3ec-9964d793a39b", "Student", "STUDENT" },
                    { "6974a4cf-cd0e-4b7c-a613-c1906c096747", "e223f45f-14c0-4726-93c8-5b8df283836a", "Admin", "ADMIN" },
                    { "41760d05-e757-4877-a039-d3679534c1eb", "1963a191-092d-44a6-8b1f-111d566ddc7f", "Professor", "PROFESSOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImageUrl", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[] { "55e556f0-703a-4853-b6d3-b3971e30bb25", 0, "2f71cad8-2f98-450a-948c-26a45ddc2058", "admin@admin.com", true, null, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAhgOIAON7k6LR/+82sJpIYqCKfyAO2KTUj/7X1Pl3l6HJwmxPeRzVDiQcItTrVfFg==", null, false, null, "", false, "admin@admin.com", 1 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "55e556f0-703a-4853-b6d3-b3971e30bb25", "6974a4cf-cd0e-4b7c-a613-c1906c096747" });
        }
    }
}
