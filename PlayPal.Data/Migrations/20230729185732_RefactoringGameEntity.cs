using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class RefactoringGameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAutoGoal",
                table: "Goals",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indicates if the goals is autogoal");

            migrationBuilder.AddColumn<int>(
                name: "AwayTeamGoalCount",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The goals scored for the away team");

            migrationBuilder.AddColumn<int>(
                name: "HomeTeamGoalCount",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The goals scored for the home team");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "5f5dd171-3827-4e44-8be1-2bc1851704cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "ba81163d-e2a5-4009-ac08-738a73511cda");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "634be541-d4f4-4b98-9593-6845950715da");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8beaf728-bc60-428c-a649-d93d4ccf9a70", "AQAAAAEAACcQAAAAEM3RGA5tLDwZVC/EGJD7IDj3nywcerMO661rrZQOTDxFHjsU7dJVpLr/of4fk45v2Q==", "8460693b-ffe5-43ed-9613-80ecc74ce7dd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "358e9cf3-2bfc-4049-a42b-88d25cf35fe6", "AQAAAAEAACcQAAAAELAealfwzz1PSTzJquIOlRm1N7e6AIoDLEKxEEevabD3a5e6xiEU/xugGw2OWHEeMw==", "7c51affa-a097-4e3c-acfa-695bf020fa47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c75b1be7-105d-4023-ad54-38e6f6d24648", "AQAAAAEAACcQAAAAEMLIn3iqOE2kEzPPe+v3f1DLBE1yfN6k4zODjkNGvSfz/WHPSrb59UVyohg/h3R0hg==", "f00ca937-382c-4e8c-8582-5157f3f5fd0b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAutoGoal",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "AwayTeamGoalCount",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "HomeTeamGoalCount",
                table: "Games");

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
    }
}
