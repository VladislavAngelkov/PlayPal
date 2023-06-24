using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class EntityConfigurationRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "IsDeleted", "UserId" },
                values: new object[] { new Guid("e4ffec5c-28f6-4bf2-8843-26e4253fad7d"), false, new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "ec4c560c-b5ed-4bf8-ba26-f53064f8f608");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "2808c00b-8eb3-4653-aa78-1d0a7e91738c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "96dbd8d8-9379-43d4-b224-8df5f853debb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09050418-5ed9-48ef-a8e2-9ee4a640c737", "AQAAAAEAACcQAAAAECj8jEkGvmxE/qTlHQAsHjR+/M3UJeIAZ6d7vAg6EAHPrWwqhfK4u+zNui1h1P56YQ==", "b5876bbc-f0b5-456f-9276-d3a0a7321e9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1404bf6-e712-4ddd-971c-dc1c4da8faf5", "AQAAAAEAACcQAAAAEMwCObXwz0kduLTRQJu6l0xEI61TUnO2hiAfpEIi/HvI+awoDOqpx3VltYrJyPKyFA==", "9165b22c-234e-4e81-b273-e865ae4f34d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa8cb543-2a6e-40b5-b413-82d2179c5879", "AQAAAAEAACcQAAAAEAbN2kwGqbPGASsaSvtGiabgZB8I6jgec9tRSJ8tyIPhm0hOLf/UoWgzyMPLPk8V/Q==", "e9de29c1-385a-4ed5-b809-52b708f27e17" });

            migrationBuilder.InsertData(
                table: "FieldOwners",
                columns: new[] { "Id", "ContactAddress", "IsDeleted", "UserId" },
                values: new object[] { new Guid("b4e0ec40-ed5e-448e-8ed1-0f69176016f3"), "Sofia, str. Vasil Levski #11", false, new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "Position", "UserId" },
                values: new object[] { new Guid("18301d69-ba23-4e2d-98bf-7064a25a5d26"), "Sofia", false, "Player", 1, new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("e4ffec5c-28f6-4bf2-8843-26e4253fad7d"));

            migrationBuilder.DeleteData(
                table: "FieldOwners",
                keyColumn: "Id",
                keyValue: new Guid("b4e0ec40-ed5e-448e-8ed1-0f69176016f3"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("18301d69-ba23-4e2d-98bf-7064a25a5d26"));

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
    }
}
