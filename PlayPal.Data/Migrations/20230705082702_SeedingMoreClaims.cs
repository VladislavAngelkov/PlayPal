using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class SeedingMoreClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "Name", "Ivan Ivanow", new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "FieldOwnerId", "568302c8-4561-4e7d-a796-1ae35b530c5f", new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 4, "Name", "Mr Georgi Georgiev", new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") },
                    { 5, "PlayerId", "6276efc4-23ea-4440-9d4a-7b164a2c74a6", new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") },
                    { 6, "Name", "Player", new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") },
                    { 7, "City", "Sofia", new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "765c7265-f385-4d2b-9cf1-4cbe9073dac8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "ba394090-9f0d-4908-906e-e0b9d2f23070");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "7e327183-49c1-4beb-a332-d39590df88b6");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "FieldOwnerId", "568302c8-4561-4e7d-a796-1ae35b530c5f", new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { "PlayerId", "6276efc4-23ea-4440-9d4a-7b164a2c74a6", new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dab5c1cb-a7da-48ff-845a-a6895157b882", "AQAAAAEAACcQAAAAELM3b2+G3BO+5SjIpTCuEwmNYQfbTtI9GU+suC2p9TSGir+W6MS064F5AAlN0hFn7w==", "d0ca2598-343c-440b-8b20-e914e5a58804" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a1a0440-f255-4b2c-945c-7f21953526c9", "AQAAAAEAACcQAAAAEBzEctoLSUKrwmDlZtff32tOEXPFomFILaUTSMEz2tD3US+mQ8B4JtcO5Yrg6abdNQ==", "bf6ab313-a711-4bcd-ab09-ad9b5637d87e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa26af01-7d14-4b52-a24a-26d210240e26", "AQAAAAEAACcQAAAAEE6rflpfO6mAIgKa74CbOVd4v4YhRbMCXYlqfF4N1mKM3nTesEpl+6KOxe+PGwMXrA==", "ca57986b-7690-4cf4-ba69-ab91b4a79fa2" });
        }
    }
}
