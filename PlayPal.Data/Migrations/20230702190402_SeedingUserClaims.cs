using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class SeedingUserClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("34e53562-17e0-4e2d-84fb-7aa4ec4e88f3"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("8d46b487-1b10-4de2-89b5-2beac2c6428f"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "UserId" },
                values: new object[] { new Guid("fd40991a-dd39-4ce0-9179-82740d6383ee"), "Ivan", false, "Ivanov", new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") });

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

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "AdministratorId", "fd40991a-dd39-4ce0-9179-82740d6383ee", new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") },
                    { 2, "FieldOwnerId", "568302c8-4561-4e7d-a796-1ae35b530c5f", new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") },
                    { 3, "PlayerId", "6276efc4-23ea-4440-9d4a-7b164a2c74a6", new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") }
                });

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

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "PositionId", "UserId" },
                values: new object[] { new Guid("6276efc4-23ea-4440-9d4a-7b164a2c74a6"), "Sofia", false, "Player", new Guid("5a491d86-fc04-4359-aef9-feca2630e6bf"), new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("fd40991a-dd39-4ce0-9179-82740d6383ee"));

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
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("6276efc4-23ea-4440-9d4a-7b164a2c74a6"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "UserId" },
                values: new object[] { new Guid("34e53562-17e0-4e2d-84fb-7aa4ec4e88f3"), "Ivan", false, "Ivanov", new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "d2830678-d5ad-4a92-9d59-d55f0abe6849");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "04fa9523-367a-4148-bf3e-56beeaa3537a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "6c1138e9-7af4-4675-8a17-4e665e6d7487");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d444fd6e-12b7-4df2-83a4-ea627078d26f", "AQAAAAEAACcQAAAAEMOAgLyWGZqEBun/YQBJX3a9lIFU5FMmADuCY2SuOcsx/o34SOvfA2trZ6WXYci8gA==", "f7fcda59-e271-4f1b-8723-4163568cd747" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41b1d6e0-cd25-49bd-acbe-303095f04901", "AQAAAAEAACcQAAAAEBXeCJbB/0Cq5XoGUIh7YKrQpdZMB30tgTwAzg6MKkLcj3KQOdkxfGIrwOHdkM5bUA==", "7a6196b1-af70-49b6-846b-018b95ad166d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8981aff-ee79-40b0-b362-bb90886718b3", "AQAAAAEAACcQAAAAEM1shknMLzzl5MTd3KUOaIb/iHJ8Rqj/tqECaEyFEEOqGvvrwr3U8y1SxwLhD171xg==", "18b9089e-1e9a-419f-8831-0c1706c2ea5e" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "PositionId", "UserId" },
                values: new object[] { new Guid("8d46b487-1b10-4de2-89b5-2beac2c6428f"), "Sofia", false, "Player", new Guid("5a491d86-fc04-4359-aef9-feca2630e6bf"), new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });
        }
    }
}
