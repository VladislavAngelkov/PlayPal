using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingSentToPropertyToMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Shows at what time the message is sent");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "20df02a7-77dd-4469-aec7-a66f8e129ee1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "296cd249-8b6a-40b1-b640-67363e58617a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "d96e8966-bdb2-46e8-9094-8704fb33cd23");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29e7e233-b8b9-4c0c-956b-47c12caf0e06", "AQAAAAEAACcQAAAAEC3Zlk5ZoO6f52qBFJJGYBVBP6XSljwcr3F3vijzLWD5r/P6FtiDMk0RVBkuVyHKnQ==", "522b0655-7677-4432-a275-8ab41637f8ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6994542-7008-42e3-8001-5e2957282a79", "AQAAAAEAACcQAAAAEEv8Gf0ExoNm1N4uodMQbkCRDcCH7w/+8IPV9ZT3M/rbkm81ODZO98FvLGMsng48Og==", "3f75b410-12ca-475a-9ae5-c50444ce05ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "782ecabd-1e62-4201-b4ea-e6f2d8950a8f", "AQAAAAEAACcQAAAAEHjrUtTmWM/eP1TAo/193ddddxYDuT6jAMig1HPmroFqOyjbY3Vs0R6iqD2VMye9Nw==", "8cb13cb3-2df2-433b-81da-82ecba0d4a4f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "Messages");

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
    }
}
