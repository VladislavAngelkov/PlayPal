using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingReportEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrators_AspNetUsers_UserId",
                table: "Administrators");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldOwners_AspNetUsers_UserId",
                table: "FieldOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_UserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_FieldOwners_UserId",
                table: "FieldOwners");

            migrationBuilder.DropIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the user, owning player's profile",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The identifier of the user, owning player's profile");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "FieldOwners",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the user, owning owner's profile",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The identifier of the user, owning owner's profile");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Administrators",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the user, owning the administrator profile",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The identifier of the user, owning the administrator profile");

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportingPlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportedPlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<int>(type: "int", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Players_ReportedPlayerId",
                        column: x => x.ReportedPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Report_Players_ReportingPlayerId",
                        column: x => x.ReportingPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOwners_UserId",
                table: "FieldOwners",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ReportedPlayerId",
                table: "Report",
                column: "ReportedPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ReportingPlayerId",
                table: "Report",
                column: "ReportingPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administrators_AspNetUsers_UserId",
                table: "Administrators",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldOwners_AspNetUsers_UserId",
                table: "FieldOwners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administrators_AspNetUsers_UserId",
                table: "Administrators");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldOwners_AspNetUsers_UserId",
                table: "FieldOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropIndex(
                name: "IX_Players_UserId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_FieldOwners_UserId",
                table: "FieldOwners");

            migrationBuilder.DropIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The identifier of the user, owning player's profile",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The identifier of the user, owning player's profile");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "FieldOwners",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The identifier of the user, owning owner's profile",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The identifier of the user, owning owner's profile");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Administrators",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The identifier of the user, owning the administrator profile",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The identifier of the user, owning the administrator profile");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "2ff6648f-26b7-44f0-9b03-6736d65b07da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "14134c2b-a1a3-4e3b-b447-f836a7f2e024");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "edfb255b-1b98-41c0-a4fe-ab80ac2126b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d20fccc9-1489-40a2-84a9-0f4023628d45", "AQAAAAEAACcQAAAAECjmYVVpqYzaOsFf7I3FbXKuvN62Ra/kfqkOrCgFnYoGaqRoSN95vE8762LgGvxU6g==", "d0b4fcfc-7557-495f-892a-574b1fd020a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a5eef323-311a-4f31-b5ca-726f38a04fe3", "AQAAAAEAACcQAAAAEGqGYJrnci3XiLe5e9wCbE0n89yP+8QThC4ddbD10tmnfAnK7sMo8/RCmSXsl7FQtw==", "cc7c8e63-57b1-4bda-b8bb-c1b529ace60c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a44deb23-389f-472f-a4b2-a0b3bcdf4a9e", "AQAAAAEAACcQAAAAEGus5pqaehPre9NDgOTVd48N3dwaC060ghLFoztQXxlwu2ektPOGgddJIYiQhfn5sg==", "c5e121fa-8fef-4d4b-a7bd-81ba4e939452" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FieldOwners_UserId",
                table: "FieldOwners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Administrators_AspNetUsers_UserId",
                table: "Administrators",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FieldOwners_AspNetUsers_UserId",
                table: "FieldOwners",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
