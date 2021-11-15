using Microsoft.EntityFrameworkCore.Migrations;

namespace User_Management_Service.Data.Migrations
{
    public partial class AddingUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "12f9414a-640d-42ac-99c5-66d36b241d0a", "ApplicationUser", "alice@email.com", true, false, null, "ALICE@EMAIL.COM", "ALICE", "AQAAAAEAACcQAAAAENELHBE23MDkAKvmwC5IkuCHne8tfTOdtCEsC/n7mYrt7WUtIylKQrS5LjsSwsSq8w==", null, false, "0219d7ea-048f-4fa4-98df-81cdcaced2ad", false, "alice" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "62625048-bef4-425d-b5be-60bfdc7f52b6", "ApplicationUser", "bob@email.com", true, false, null, "BOB@EMAIL.COM", "BOB", "AQAAAAEAACcQAAAAEN+mwOdHlwjML6A7c79hOo/6Jg1a8yr/DmVjku7HoUzEcqfVS2IEPfAmYCB6gF20OQ==", null, false, "3a14775f-d204-40bd-927c-90a426e56b5f", false, "bob" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3", 0, "b12dec23-9708-455c-84dd-4a7082a7ad76", "ApplicationUser", "joe@email.com", true, false, null, "JOE@EMAIL.COM", "JOE", "AQAAAAEAACcQAAAAEIBNmvhxdNzCzP82D1TiPegUt6Glbu6MPOQ/9kWVPpyBI41jEoVNrHsBNkJhnxIBUw==", null, false, "aa5f3dce-655d-40fb-a4f1-bdf484ee7598", false, "joe" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "name", "Alice Smith", "1" },
                    { 27, "claim_apiscope1", "apiScope1 claim rocks!", "3" },
                    { 26, "claim_apiresource2", "apiResource2 claim rocks!", "3" },
                    { 25, "claim_apiresource1", "apiResource1 claim rocks!", "3" },
                    { 24, "claim_idresource1", "id claim rocks!", "3" },
                    { 22, "employeetype", "employee", "3" },
                    { 19, "employmentid", "1236", "3" },
                    { 9, "family_name", "Joe", "3" },
                    { 6, "given_name", "Joe", "3" },
                    { 3, "name", "Joe Smith", "3" },
                    { 32, "paymentaccess", "read:write", "2" },
                    { 29, "creditlimit", "20000", "2" },
                    { 21, "employeetype", "consultant", "2" },
                    { 18, "employmentid", "1235", "2" },
                    { 16, "address", "{ 'street_address': 'Two Cyber Way', 'locality': 'Stockholm', 'postal_code': 23456, 'country': 'Sweden' }", "2" },
                    { 14, "website", "http://bob.com", "2" },
                    { 8, "family_name", "Smith", "2" },
                    { 5, "given_name", "Bob", "2" },
                    { 2, "name", "Bob Smith", "2" },
                    { 31, "paymentaccess", "read", "1" },
                    { 28, "creditlimit", "10000", "1" },
                    { 23, "admin", "yes", "1" },
                    { 20, "employeetype", "employee", "1" },
                    { 17, "employmentid", "1234", "1" },
                    { 15, "address", "{ 'street_address': 'One Hacker Way', 'locality': 'Helsingborg', 'postal_code': 12345, 'country': 'Sweden' }", "1" },
                    { 13, "website", "http://alice.com", "1" },
                    { 7, "family_name", "Smith", "1" },
                    { 4, "given_name", "Alice", "1" },
                    { 30, "creditlimit", "30000", "3" },
                    { 33, "paymentaccess", "read:write", "3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
