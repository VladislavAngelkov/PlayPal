using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class UpdateingMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ReceiverId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the user, that has received the message",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The identifier of the user, that has received the message");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "47088e57-cf41-4d1e-9b7d-9efecf318c04");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "85229c67-a6f9-4b86-8aaf-f9155ed38937");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "dd31307d-15be-46b7-a58a-ece1c24a631c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "844bbd1f-ee8d-445f-b17c-ffc024b3a35c", "AQAAAAEAACcQAAAAEGmnZ6YKQh4VhTy+eMg+XNnAXBdQTxo5pSncwXH4LsXK/wooG3uEMtva7tX3cFFpWA==", "5bdcb52e-8f3c-4e63-95ec-0da794fe0195" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae12434b-a705-408a-95fa-487e97e6b428", "AQAAAAEAACcQAAAAENhfALIO4RVQwGEHnuV0Iy7pgTG07hTngQ1UhKfrjmAJXMGJoA4h+fF1ykJ7m2WaEQ==", "d2c200ca-655a-4412-809f-06b5d9c7d948" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e4dac3b3-50be-48ae-8803-4a5fe70402dd", "AQAAAAEAACcQAAAAEDKnlVzdpgGtrlx6EobyuNbphMkl/DyHy7r93eIvpzRCpjVzThyjtHYhUMOYFY0WDQ==", "4459e93d-add1-4a7e-a892-d221fdc57eb5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ReceiverId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The identifier of the user, that has received the message",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The identifier of the user, that has received the message");

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
    }
}
