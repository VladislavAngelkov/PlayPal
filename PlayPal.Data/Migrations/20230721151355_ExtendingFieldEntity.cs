using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class ExtendingFieldEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Fields",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "The name of the field");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "bf26b3a1-05ee-4a25-a315-426aa0e542fa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "8229da49-15c8-412f-bf49-69e0843c00dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "c91d7d2f-903c-446e-beb4-2568a0651c96");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b1cf476-342e-4b61-826b-1209f837e86e", "AQAAAAEAACcQAAAAEJm4p3xA3WQQm+MBkwRBK0dG1DUHscp/Igtv/lNB0YNK2kqp8yy9u6gYQoe53uEATw==", "d7d96b05-3a88-4c19-9a0e-8234494de33c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e17ce77f-54cd-4d1a-83e8-0d567a64440b", "AQAAAAEAACcQAAAAENmztjNdYrFkrDW/LKUIcdK2HuWz3FFa3S7dzd7/TTusXTzmnk7Dy+zWbaxv8XrMbA==", "15098031-d5dd-498d-8f2e-28e5eae968ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b60c04bf-7095-4b4c-b747-c46bc4fd10c4", "AQAAAAEAACcQAAAAEEjrb45iJeRMQiN06Awey2tnxwmhfshF35Iynv0oheEMlG98Qrgm3E0JG4riUbjL+g==", "967c3c83-09b8-41db-8c72-80d8e04e7696" });

            migrationBuilder.UpdateData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: new Guid("06921ef3-e09a-456d-92ef-aada394af8bb"),
                column: "Name",
                value: "Football Ground");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Fields");

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
    }
}
