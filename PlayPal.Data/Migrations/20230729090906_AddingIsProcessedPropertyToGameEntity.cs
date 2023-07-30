using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingIsProcessedPropertyToGameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indecates if the game is processed by the creator after its over.");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "76226ec9-23bd-45ba-b9ae-f4946cf8312d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "e27d6837-8d60-4514-8868-578fefe7acf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "80b6b2c0-d4fe-41b1-908c-3a98aff65cac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b853a939-2768-434f-bf81-e9960741277c", "AQAAAAEAACcQAAAAEJwGjA1/s1uPIqn29yDgDwGuWWVjt5eWwatQFb5Ci7+rg+Ux5rUtJUyaIkr450AEuw==", "a2d08c98-c373-451a-b609-50b19bb7cf75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a603d6d5-7b1d-4220-a676-6b01208db895", "AQAAAAEAACcQAAAAENiOyEpLUeA8HOevA7njjQUpVka1k3OXhAQsbE7DigDlOc8UDSpdr1ehLiHKC/NuBA==", "960b4976-6fe0-45c8-a33f-d160d1006277" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bcea067-b2fe-4fc5-bf78-564a07d2f916", "AQAAAAEAACcQAAAAEApWCM+ZdnLdyTl7lDXInM4eLDg02GJiihasBMCSRAA14nSJzS7GA2QfPiOg9EXiIA==", "4ae3152f-bf35-410a-b3f6-9d8dc48d37b7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "b1178909-b35e-435e-8f5e-ae59f1d77d74");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "73483d44-fa76-4b9a-8257-01ad5b338bf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "6635b683-6cb2-4528-b13f-4a6af64f2014");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8999b8dd-9175-4f54-9f6d-9c8e25c18090", "AQAAAAEAACcQAAAAEJ4M5hELEoitwDCMl+uaR3OJL2uzG33VfQFWdh0PG8GybEElnX2JJ8pp4kNkYvUSaA==", "c7af1883-16e8-4043-8954-fa81ea94a2d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09db1354-cb4c-4664-b284-48dd2236caba", "AQAAAAEAACcQAAAAEPhtJhlSK3WESfY6EGtL6rxD9mvPtIZb/QepUerqOONb3aTVraIi4KPLTvgDzExMmQ==", "8b724249-6030-42c2-88c5-79de2eed88dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "632326d7-0d7b-4032-9d00-5e44360fd44d", "AQAAAAEAACcQAAAAEDfTFQaVDq54+9bhHxvzllSGGotzygveOt5PW8hAVinVDNX/YHzqLKlcCaKF43glrw==", "0e0d2585-de0c-49f4-ad7a-871e7aac95ac" });
        }
    }
}
