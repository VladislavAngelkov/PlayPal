using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class FixingTeamAndGameEntitiesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_AwayGameId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_HomeGameId",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "HomeGameId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the home game, in which the team played",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The identifier of the home game, in which the team played");

            migrationBuilder.AlterColumn<Guid>(
                name: "AwayGameId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the away game, in which the team played",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The identifier of the away game, in which the team played");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "0a89eeb4-8f52-4633-ba31-469c8036cf3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "2aef1b9e-a677-4078-bc7b-1146f2ce0c1d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "f7f7b959-0e52-4c33-b662-2f6a8b885c15");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9458d885-386b-4a61-bd93-750d6e78d064", "AQAAAAEAACcQAAAAEGBGUNhisKfrtCWEp61VsK4OymSoCqdIYUgeiBhf7Ujc4/IEh/sZXJOhKX1vBXzobQ==", "88bdaded-11ed-4b9c-826c-fe7029869fd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c204760b-800e-4987-bac7-c3722ec517f5", "AQAAAAEAACcQAAAAED8hF/qEQELXR0Lj963bYtqFFV90gLKDjiV05I+jdSTFGOUaQssl2rIDg+UkKd60Ng==", "d931f5f9-76be-4593-bb5b-b82ecd942fe0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0bfed2fc-6506-41d6-9f05-dc8952db734c", "AQAAAAEAACcQAAAAEIINTBp8ZyMrgAgm4G3Dsvx1QFbE6HD1vUOfHLDWu9/mG9eHbfr0INEV1pm1aIxATQ==", "1ad752da-1e94-4a9c-ab09-3323924b8f32" });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AwayGameId",
                table: "Teams",
                column: "AwayGameId",
                unique: true,
                filter: "[AwayGameId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HomeGameId",
                table: "Teams",
                column: "HomeGameId",
                unique: true,
                filter: "[HomeGameId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Teams_AwayGameId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_HomeGameId",
                table: "Teams");

            migrationBuilder.AlterColumn<Guid>(
                name: "HomeGameId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The identifier of the home game, in which the team played",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The identifier of the home game, in which the team played");

            migrationBuilder.AlterColumn<Guid>(
                name: "AwayGameId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The identifier of the away game, in which the team played",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The identifier of the away game, in which the team played");

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

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AwayGameId",
                table: "Teams",
                column: "AwayGameId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HomeGameId",
                table: "Teams",
                column: "HomeGameId",
                unique: true);
        }
    }
}
