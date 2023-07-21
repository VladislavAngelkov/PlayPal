using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingTitleToMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Messages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "The title of the message");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "a4fb51af-e544-45e2-b8f0-9dc495a8b4d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "7f9f4c24-26d5-4933-a1f1-1e97c51b4194");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "4d71faad-de36-4bb9-92da-0888bce70656");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26e1ed11-a676-446e-8a5c-ca50b68992e9", "AQAAAAEAACcQAAAAEP+ccJidlvtjclq5b/S/ssZaX1SrDLB7tUMVNTHQRrbg8Rn4FW/sCIUu+QSlafdlGw==", "b7008f6e-9dfb-4b0c-8094-9f6a78312ebf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "058237d8-590f-4879-bcb1-425620e6963d", "AQAAAAEAACcQAAAAEON4ysseR+e4wqgPce1kzs6TsKcFO0EQgEBeV/ViNB8F/eBNwbWXyMHzcGjtIr60Uw==", "ec0a136f-ba47-49d8-b0d4-5c3d6bd4a237" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c367fc17-0b5b-4256-a12a-dc1ad8504f6d", "AQAAAAEAACcQAAAAEE4+hjTZ+dOwoRDMbp4YQLJJsE74XRyTedByi8NXE2J8sR/WICC0wlz8x8VBMpHxcA==", "25321e71-4c13-48aa-8010-8f8cb3b46f00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "7a58e7bf-4b64-4928-82ab-0ee4a906df88");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "f6c007b6-7f5c-467d-8236-943db053f708");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "87643052-dd47-4dfd-b489-02cf35488b3e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a695b3c0-7071-4ca0-97e6-9c64fcf4b51d", "AQAAAAEAACcQAAAAEKMkMnSk3ZbIuPRsWgDKneBKK4cbL9DF/duNjpdwEqbwO8ZsJZMAILiEF+YccyQ/zQ==", "c5985c77-38c8-4d9d-a618-e52256b43185" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15414a66-2156-486e-87fc-a50d11355db5", "AQAAAAEAACcQAAAAEK5Px2JvPVqDyXGNmVA+j2SVo6Zx/W0dQsRSqEiN4fqtETq5nycAW+YurBILE7RkYQ==", "85cebbc3-fffe-4a99-bf70-d291a7dc65b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5104b02a-6a01-42b9-86e0-4ef62c0f0890", "AQAAAAEAACcQAAAAEA5p2YLK/BnoDQ/3LQ87vlyWDxG2gTCsIyLr/76TXAqjHuDyIrxpg5vz+cUkHGtsPw==", "da0e1515-a2c5-4d88-af52-0762b886fa88" });
        }
    }
}
