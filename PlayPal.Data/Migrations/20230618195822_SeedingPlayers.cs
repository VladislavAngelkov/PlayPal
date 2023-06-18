using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class SeedingPlayers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "24a187df-425a-4f07-88cf-a205213240d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "86021bc6-9330-4cf2-a711-26adfaf13026");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "2b499a8a-601b-4a6c-868f-084cb5500759");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37cd0941-9377-4934-b87d-97ec8444ad60", "AQAAAAEAACcQAAAAEDpkSmb/Jp3tJ/79ETeNTTLS63cfVOiiVVFOazyCS8jVE8uWUSq98Zl/xKWBIxa35g==", "c18ec227-a76c-438a-99fb-e3efd7dc7ff8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09b27cdd-3b87-4e63-b8d2-5b08b542c68c", "AQAAAAEAACcQAAAAEJB13NlmztgSJMGyoQrEpWvJhwbqCnosMhL5TXNQl2NsaAjAoy0+KifiDHUg41tWmQ==", "57b8cd28-d226-4774-9564-19ad5a11f7a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8def9a76-a154-4858-9788-724006c304a0", "AQAAAAEAACcQAAAAEE5NTIbUPmQP71LrPzZAc0YX/V9sDt92yGQV2QihfqLs7zXxdO2wXEINp0VS9ZkpKg==", "893b0342-d5f7-448b-8ccd-bce47a28a50f" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "Position", "UserId" },
                values: new object[] { new Guid("e47a87c2-a255-40b5-9c7e-0ce9221a9746"), "Sofia", false, "Player", 1, new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e47a87c2-a255-40b5-9c7e-0ce9221a9746"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "7712b37c-2624-4115-ae23-5864bf4020b7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "e7631731-d800-43b5-95ec-7543c33cde3f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "c06f4ced-1a74-4d67-815c-164831843256");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61a3fe97-7f8b-4255-8685-2bbd9a38a3cc", "AQAAAAEAACcQAAAAEJlNQWyr496OnCLGXfElJS2AYD7EFNRcgkB0rjcdY6dbQEbzvKtCC97Hucu1CU3OHA==", "b9d8ebd5-f5d9-4c01-acc9-03a06ec59b01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ecc1bbf7-8d81-44ca-9f9d-0a707c00322b", "AQAAAAEAACcQAAAAEHon03T/gaj7ElCT64LenbaxPOZEesadU0KuHyR7IkRnRXnnnXMlYvB1iLvvpHoKXw==", "944aae11-af63-4894-ba96-2c1a67baf28f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdbf20b2-b8ea-4c4f-8df1-58c56e170972", "AQAAAAEAACcQAAAAEPLSTfxmbQwWzXV3bQPMP72z82DRVrlpdSb7ZwKElR/naq84CI5wZNgHaQexeHXyaw==", "97835b9b-4b17-4701-9a11-2d6c15afe728" });
        }
    }
}
