using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class SeedingFieldsAndChangingFiledEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("4ccb117a-30b2-4f85-a054-68aa08e801fc"), false, new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "33dc8dd0-1a72-440d-b63c-57605c9444d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "f88030b1-75f1-4fd3-a949-67fc96de2816");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "8fa463b1-e1ab-445a-9fdb-66bcb96bf11a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e5adc9b-acd1-4e60-aec5-b239dfe6bfde", "AQAAAAEAACcQAAAAEJQmjvvKWxY5bP4qLKrfqj/MDvhgByleatZ0jZnrOQA4Y4vYcYg6uCQfMcowshipHw==", "05154771-a684-42be-8436-6fa63aba885e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e5c40e0-020c-475c-ac98-8e886f97bd1d", "AQAAAAEAACcQAAAAEJrvyAarjdqRYMgKN5k0h7dSqsajMcCAYtA5T9iSnIwjPwlBsx/F1kMr+VegJ1oYmg==", "a4a6941f-f7cb-4393-a0b3-b86fcbdbae62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3665dbe6-87d1-4484-9858-5559926bb9f0", "AQAAAAEAACcQAAAAEOwrbmQHINgr7aqRubS30ejeTiBcqTiMfwLLwil5elO4VUKs6Wsfth3nwSb5jVsclA==", "c5560891-72e1-4046-8c1d-030cbfc0d2a8" });

            migrationBuilder.InsertData(
                table: "FieldOwners",
                columns: new[] { "Id", "ContactAddress", "IsDeleted", "UserId" },
                values: new object[] { new Guid("568302c8-4561-4e7d-a796-1ae35b530c5f"), "Sofia, str. Vasil Levski #11", false, new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "Position", "UserId" },
                values: new object[] { new Guid("899825ad-19d1-4d22-be3b-e562dbcd12f3"), "Sofia", false, "Player", 1, new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Address", "City", "IsDeleted", "OwnerId" },
                values: new object[] { new Guid("06921ef3-e09a-456d-92ef-aada394af8bb"), "str. Hristo Botev 36", "Sofia", false, new Guid("568302c8-4561-4e7d-a796-1ae35b530c5f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("4ccb117a-30b2-4f85-a054-68aa08e801fc"));

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("06921ef3-e09a-456d-92ef-aada394af8bb"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("899825ad-19d1-4d22-be3b-e562dbcd12f3"));

            migrationBuilder.DeleteData(
                table: "FieldOwners",
                keyColumn: "Id",
                keyValue: new Guid("568302c8-4561-4e7d-a796-1ae35b530c5f"));

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
    }
}
