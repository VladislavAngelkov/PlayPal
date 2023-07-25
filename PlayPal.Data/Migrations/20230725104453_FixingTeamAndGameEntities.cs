using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class FixingTeamAndGameEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Games_AwayGameID",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Games_HomeGameID",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "HomeGameID",
                table: "Teams",
                newName: "HomeGameId");

            migrationBuilder.RenameColumn(
                name: "AwayGameID",
                table: "Teams",
                newName: "AwayGameId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_HomeGameID",
                table: "Teams",
                newName: "IX_Teams_HomeGameId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_AwayGameID",
                table: "Teams",
                newName: "IX_Teams_AwayGameId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Administrators",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "The last name of the Administrator",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Administrators",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "The first name of the Administrator",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "de9df4ee-e45a-4193-9cb6-24119043e489");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "e1a7e6b4-502f-4426-b04c-a885823f7822");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "f2cacb37-e89d-423f-8da9-870851831d08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3775fe40-2a85-498e-b471-5d601e4eccd1", "AQAAAAEAACcQAAAAEMFdBbVWGhk5S551UYGxqKVOwE1Uem+o2aG5OhT3v/Qyo+dRPAHLlLUXHR0Y7eItCw==", "e3ad30ad-7245-416b-b6c8-5bbc2fa5539f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f478b69b-1cac-49b5-8dd0-b9a7a7ed280b", "AQAAAAEAACcQAAAAEG7H/t2hxvGpwXr/FAteD++V7rdlkg7JjuICXazm6BryhPjauUFuF9JOJ4pO384bgA==", "fa54178f-57a9-4f62-b6f3-940886f3a0ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ccaa114-c310-4bde-80bd-4e6459ce4fb1", "AQAAAAEAACcQAAAAEOtjnJXlngaE3rW2GbtuvXHywtaDGIJPWlRJlzpHh1Oef9QpjQ1qelhiA/q3XZGFwA==", "9c9e775e-b50b-4302-9f35-abb3a8335384" });

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Games_AwayGameId",
                table: "Teams",
                column: "AwayGameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Games_HomeGameId",
                table: "Teams",
                column: "HomeGameId",
                principalTable: "Games",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Games_AwayGameId",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Games_HomeGameId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "HomeGameId",
                table: "Teams",
                newName: "HomeGameID");

            migrationBuilder.RenameColumn(
                name: "AwayGameId",
                table: "Teams",
                newName: "AwayGameID");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_HomeGameId",
                table: "Teams",
                newName: "IX_Teams_HomeGameID");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_AwayGameId",
                table: "Teams",
                newName: "IX_Teams_AwayGameID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "The last name of the Administrator");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "The first name of the Administrator");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Games_AwayGameID",
                table: "Teams",
                column: "AwayGameID",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Games_HomeGameID",
                table: "Teams",
                column: "HomeGameID",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
