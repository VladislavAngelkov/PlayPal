using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingNormalizedCityToPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NormalizedCurrentCity",
                table: "Players",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                comment: "Normalized name of the player's city");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedCurrentCity",
                table: "Players");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "cde4f9ba-84bb-4093-aecb-69fd463d8243");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "2b4dc61b-9ce6-4e90-906d-cf894737008c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "a3d4df22-bfc3-45fa-a41b-a0a0c827657d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "218388f9-c35b-433e-90d9-2e95b4623461", "AQAAAAEAACcQAAAAENRoWW9CI8PSkvyyHPwRK5MDopOwc5fY5tU4hzbNvQupYdItxAECxskg/igTuaVF1Q==", "01d0fa57-4fa1-407a-9b3a-7ad9e28bade7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6192bb93-534f-400e-8e6b-a0df423d68c5", "AQAAAAEAACcQAAAAEIG3UhbMnfvouOjbbCvGNuArCVK0ZVQgOQlTner7VWVHZYpA7RaUboNcYamqrC+Wpw==", "4ebdc6fe-55ad-486e-876f-1682dfeb56c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e66daae-de88-40ab-952e-19d39a2194fb", "AQAAAAEAACcQAAAAEGX60v/ca3PzQFy6dm33nkUz6QR9mC7uauggOXysAeFFuvOAZRJy16boL9hMLnNYYQ==", "abc84277-bbf3-4336-b6b4-10e5494ae5f8" });
        }
    }
}
