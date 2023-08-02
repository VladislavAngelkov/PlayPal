using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingProfilePicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The indentifier of the profile picture");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "289ed9de-26b3-4171-a886-37d7d24cb9b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "aae359f6-f2ff-4a67-a9c8-808a7eca8ced");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "60e85ee1-5b49-4665-9f28-01dac863ae66");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "010182b0-b86a-400d-b5d7-abcd1a3498cc", "AQAAAAEAACcQAAAAEKnZXLvfAiHR17GcyEvNGqYjE8gCiBGDwPckZcSELAoSAuxPYHh2rgC10/CsYrR+kQ==", "8b695617-a1de-4d62-b786-107487261b24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "658a89be-6c4b-4349-9a50-b5f4a332ce6c", "AQAAAAEAACcQAAAAEJn5iT02Bz+NcBr5NIe7/9CZ7qEDiKnOQ29FcGwTOQIEPj60p0ezgocaRlbDKND4rw==", "01a8f3d3-719f-4ef7-a950-c000d0e57013" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20eb39db-5f73-4420-877d-868155e74cf0", "AQAAAAEAACcQAAAAEPIJOd32fvAA4GzsZxk+qgHlOr/ivJxF4XMrZB8mOAf1Nkm5FnF8ofCpXTfT33ehbQ==", "3296e2bf-a6b4-4042-aa29-a881af8ff207" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "AspNetUsers");

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
    }
}
