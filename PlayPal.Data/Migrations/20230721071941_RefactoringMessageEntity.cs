using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class RefactoringMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Marks if the message is seen by receiver");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "51e0c919-5ad1-45a5-b2c8-09c84c4232f1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "b43b6b82-d9f7-4cbe-9ae5-0908d9365192");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "25dd5c1a-8cf5-4b26-9af6-b2ba2578c0fb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3df8817-c42c-443a-b0ad-b7f9ee925bb5", "AQAAAAEAACcQAAAAEKegADRW8RNyFL1j8atzgXXBivOLS2Vpyky8zDmuO5kaua2tNRwkqMziTN+HZ92OJQ==", "f3fc4fdf-331f-4213-b738-4a22b199066d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59b1f41a-103d-4d4e-b41f-3bda039744c3", "AQAAAAEAACcQAAAAEAQKQN9Kk9Q4D40fp1ynpuQbBKMNjbNNXxT46JvcF0yfFVhvpKYpMG0ffCdOm4+gEw==", "89c75786-f120-4028-8bcd-9dac8a98f772" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0f3fbca-ded8-4dfe-9e90-bac2e8a451af", "AQAAAAEAACcQAAAAEE0OiGHm6d9/vHtcErwfrxXJPqsm4lnKRC8572NIgDXi+ebGELmUtUzqqX32uDX5+Q==", "0ef0866e-b413-4b75-8a1a-86353763c14d" });
        }
    }
}
