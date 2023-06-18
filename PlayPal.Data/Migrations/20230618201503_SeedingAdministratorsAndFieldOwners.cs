using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class SeedingAdministratorsAndFieldOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("e47a87c2-a255-40b5-9c7e-0ce9221a9746"));

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "IsDeleted", "UserId" },
                values: new object[] { new Guid("bf82c049-3b26-4218-ab72-87d5b5811d72"), false, new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "15a4397b-ee25-4961-b681-c66798bcfd71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "b79d3c93-309f-4fc0-8320-c45e99289998");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "5c810caf-8dd4-4331-9acf-21dd3e0b5d89");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e21dcb65-c1a2-4a2e-9739-4543b6a514c2", "AQAAAAEAACcQAAAAEJNZRr4SBkdNdPX3xRG7IKkAfbMgQTXCPDheEZK5KmIpAYV1JK+YxbdMAW2/+ojlDA==", "5f3237ec-72d7-44b9-a149-5193d97765a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a44910a4-bc77-4206-a7ea-1ffcfa663ccd", "AQAAAAEAACcQAAAAEIQ1tBTdJPBtuflzKVOTOfZiHsn5dQi2Z5gg4pb+bVOR/itmUhjBym6AO3vq5SIn8w==", "8ce59901-3be5-49b3-bc9a-2d4bbe88bc23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a9261381-e585-4dc5-95f3-f68a765eb9f7", "AQAAAAEAACcQAAAAEJIPRBl28pl9MCScT3IeI0UbNJQDNReKEhrWQ+NACZsNZgivYMhdoJFmmp6e035fDg==", "847e5f32-8b57-433b-8d19-757cf7eccd84" });

            migrationBuilder.InsertData(
                table: "FieldOwners",
                columns: new[] { "Id", "ContactAddress", "IsDeleted", "UserId" },
                values: new object[] { new Guid("e1e31ae4-2adc-4ac5-b537-fe9acfc3fa9f"), "Sofia, str. Vasil Levski #11", false, new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "Position", "UserId" },
                values: new object[] { new Guid("b386594e-9a44-4304-93f8-67d786509b7e"), "Sofia", false, "Player", 1, new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("bf82c049-3b26-4218-ab72-87d5b5811d72"));

            migrationBuilder.DeleteData(
                table: "FieldOwners",
                keyColumn: "Id",
                keyValue: new Guid("e1e31ae4-2adc-4ac5-b537-fe9acfc3fa9f"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("b386594e-9a44-4304-93f8-67d786509b7e"));

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
    }
}
