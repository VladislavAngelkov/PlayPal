using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class FixingSeedingClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "2ff6648f-26b7-44f0-9b03-6736d65b07da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "14134c2b-a1a3-4e3b-b447-f836a7f2e024");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "edfb255b-1b98-41c0-a4fe-ab80ac2126b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d20fccc9-1489-40a2-84a9-0f4023628d45", "AQAAAAEAACcQAAAAECjmYVVpqYzaOsFf7I3FbXKuvN62Ra/kfqkOrCgFnYoGaqRoSN95vE8762LgGvxU6g==", "d0b4fcfc-7557-495f-892a-574b1fd020a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5eef323-311a-4f31-b5ca-726f38a04fe3", "AQAAAAEAACcQAAAAEGqGYJrnci3XiLe5e9wCbE0n89yP+8QThC4ddbD10tmnfAnK7sMo8/RCmSXsl7FQtw==", "cc7c8e63-57b1-4bda-b8bb-c1b529ace60c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a44deb23-389f-472f-a4b2-a0b3bcdf4a9e", "AQAAAAEAACcQAAAAEGus5pqaehPre9NDgOTVd48N3dwaC060ghLFoztQXxlwu2ektPOGgddJIYiQhfn5sg==", "c5e121fa-8fef-4d4b-a7bd-81ba4e939452" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "81e82960-618e-4fe1-9744-628c29d475b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "2c12c837-3f17-4f23-b6c5-b151bedc4d5f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "c1e43909-4819-4a19-b530-d31dff6705cc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "693cacba-5300-4f61-b479-2bbb947c738f", "AQAAAAEAACcQAAAAEM3h4KFRorSlwLLNx1hLlNuGbFfRMvCVCxECHuHKJWNGNQEEgyw5JT2tQ+CvZFcvyQ==", "f6b2ab09-d690-4eab-b879-93aab61d7b6f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c586ae31-3395-4048-a21c-be2e01fde7bb", "AQAAAAEAACcQAAAAEJ0FMGGZ/g2PMU3Md1wg2n5BWVZTmg6l++FFLz+VJ1WhrbQZITGchpQ4uTBtUhT8ug==", "71024b01-e7f9-479a-936e-67997b641116" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c19d885-65e5-4a4a-b91e-aba0d0e2a266", "AQAAAAEAACcQAAAAEFMmgViC5hOYQaWGkGwtoJwWMruru4bxBUtGy0IlrBOPW0spOZmG+zv+ldJ1RZXo6w==", "8a912ac4-4eea-43b2-b5b2-8d8eeaf2b665" });
        }
    }
}
