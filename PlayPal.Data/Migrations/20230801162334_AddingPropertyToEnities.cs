using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingPropertyToEnities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureId",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The indentifier of the profile picture");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureId",
                table: "FieldOwners",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The indentifier of the profile picture");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureId",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The indentifier of the profile picture");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "68c8ab2d-1e11-4ddc-a0ad-fb0fb4bb1f0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "d883f36f-b90a-47de-b12f-4ab861bdd172");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "6bc4d810-cfc4-46c1-98b9-c65a1cc88ba5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09241f79-67aa-46b8-9e12-c8fbda6853b7", "AQAAAAEAACcQAAAAEGYn6oJQ0mIAEUE0TBc/4IXq7os29MHC2wJeJNSRCSRzfqaaQyTPkzAahNKh+nitaA==", "2a5b65bb-717b-4985-a832-5c71f52aa6a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "649b637c-b152-453f-8f1e-eead20bf7db9", "AQAAAAEAACcQAAAAEMcDjRdU+haWRPKRlbaScHWy8n2DZR4VxFgvMweDYcfDTIq7uyZqmRGwzBlB/e+5EA==", "0216991d-e56a-489a-9914-23cb531d58bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2923959-15e3-493c-8c71-d18136138462", "AQAAAAEAACcQAAAAEJpF0Hf/8nWafHDEAXO7P8L5eVa/D0oze6NYuujcadzz7ThrzJAmFWJziq4oHcURVg==", "9a1b655b-05c5-453b-846c-5fa288b3ff08" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "FieldOwners");

            migrationBuilder.DropColumn(
                name: "ProfilePictureId",
                table: "Administrators");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                comment: "The indentifier of the profile picture");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "289ed9de-26b3-4171-a886-37d7d24cb9b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "aae359f6-f2ff-4a67-a9c8-808a7eca8ced");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "60e85ee1-5b49-4665-9f28-01dac863ae66");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "010182b0-b86a-400d-b5d7-abcd1a3498cc", "AQAAAAEAACcQAAAAEKnZXLvfAiHR17GcyEvNGqYjE8gCiBGDwPckZcSELAoSAuxPYHh2rgC10/CsYrR+kQ==", "8b695617-a1de-4d62-b786-107487261b24" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "658a89be-6c4b-4349-9a50-b5f4a332ce6c", "AQAAAAEAACcQAAAAEJn5iT02Bz+NcBr5NIe7/9CZ7qEDiKnOQ29FcGwTOQIEPj60p0ezgocaRlbDKND4rw==", "01a8f3d3-719f-4ef7-a950-c000d0e57013" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20eb39db-5f73-4420-877d-868155e74cf0", "AQAAAAEAACcQAAAAEPIJOd32fvAA4GzsZxk+qgHlOr/ivJxF4XMrZB8mOAf1Nkm5FnF8ofCpXTfT33ehbQ==", "3296e2bf-a6b4-4042-aa29-a881af8ff207" });
        }
    }
}
