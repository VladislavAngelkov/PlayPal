using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingReportsToDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Players_ReportedPlayerId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "FK_Report_Players_ReportingPlayerId",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Report",
                table: "Report");

            migrationBuilder.RenameTable(
                name: "Report",
                newName: "Reports");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ReportingPlayerId",
                table: "Reports",
                newName: "IX_Reports_ReportingPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Report_ReportedPlayerId",
                table: "Reports",
                newName: "IX_Reports_ReportedPlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reports",
                table: "Reports",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Players_ReportedPlayerId",
                table: "Reports",
                column: "ReportedPlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Players_ReportingPlayerId",
                table: "Reports",
                column: "ReportingPlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Players_ReportedPlayerId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Players_ReportingPlayerId",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reports",
                table: "Reports");

            migrationBuilder.RenameTable(
                name: "Reports",
                newName: "Report");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportingPlayerId",
                table: "Report",
                newName: "IX_Report_ReportingPlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reports_ReportedPlayerId",
                table: "Report",
                newName: "IX_Report_ReportedPlayerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Report",
                table: "Report",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "92efceb1-c5bf-4bd5-aaa1-5ad0704571c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "24a93317-bb0a-41cd-93fb-fc5592aa2ea4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "084809a8-a847-417a-b37b-08c8149f53a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18813701-fb5c-479d-8fd4-cc66a0fe1632", "AQAAAAEAACcQAAAAEIZGM4VGHbDWdtCLQqTXJSQCi5nPJO9uTcKRBTQ485Rsje4yjBfYcBivfIIRFtY+RA==", "21cfa962-15b2-4717-90b5-173c8888a194" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77dc3b94-d4a9-4183-b856-bde1d8d405c1", "AQAAAAEAACcQAAAAEH+o0hShTncx35MJ1TvKGi2sivGbosI+YtkkQu6WlMXTdPZLc1fH3gX118ZoAU/V7g==", "c75aac39-5979-444e-a6bb-9e77852185b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73ab7ac7-bcd3-41d0-82d1-8609c05ca33e", "AQAAAAEAACcQAAAAEAcjGBELOGbxwXHMfXCAlKJnacGG4x1nrmNo80zv4pPLNSHAwHzAEjbEg/67Vx1CbA==", "3106edd5-3408-4523-be17-9242c82b9c32" });

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Players_ReportedPlayerId",
                table: "Report",
                column: "ReportedPlayerId",
                principalTable: "Players",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Players_ReportingPlayerId",
                table: "Report",
                column: "ReportingPlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
