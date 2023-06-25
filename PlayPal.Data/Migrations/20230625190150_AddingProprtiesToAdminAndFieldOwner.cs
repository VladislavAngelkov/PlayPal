using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class AddingProprtiesToAdminAndFieldOwner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("4ccb117a-30b2-4f85-a054-68aa08e801fc"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("899825ad-19d1-4d22-be3b-e562dbcd12f3"));

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "AspNetUsers",
                newName: "FieldOwnerId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Teams",
                type: "bit",
                nullable: false,
                comment: "Indicate if this administrator profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this team is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Players",
                type: "bit",
                nullable: false,
                comment: "Indicate if this administrator profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this player profile is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                comment: "Indicate if this administrator profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this message is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Goals",
                type: "bit",
                nullable: false,
                comment: "Indicate if this administrator profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this goal is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Games",
                type: "bit",
                nullable: false,
                comment: "Indicate if this administrator profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this game is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Fields",
                type: "bit",
                nullable: false,
                comment: "Indicate if this administrator profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this field record is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "FieldOwners",
                type: "bit",
                nullable: false,
                comment: "Indicate if this administrator profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this field owner profile is considered deleted");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "FieldOwners",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "The name of the company that owns the field");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FieldOwners",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "The first name of the representive of the company that owns the field");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "FieldOwners",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "The last name of the representive of the company that owns the field");

            migrationBuilder.AddColumn<int>(
                name: "Title",
                table: "FieldOwners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "The title of the representive");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Bans",
                type: "bit",
                nullable: false,
                comment: "Indicate if this administrator profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this ban is considered deleted");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the player profile, that is owned by this user.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "The identifier of the player profile, that is owned by this user.");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Administrators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "UserId" },
                values: new object[] { new Guid("9532ac14-2efc-4345-aff7-2cbae927886b"), "Ivan", false, "Ivanov", new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "2193d0de-2deb-4151-9514-0d8ffacda5cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "c85d80b2-bf51-4089-9ec5-8ccee776caab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "79f9eacb-b0b4-40d9-bc87-3e2a60c5b3fb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PlayerId", "SecurityStamp" },
                values: new object[] { "64d9e88b-0542-4011-8c54-0da30685cf6b", "AQAAAAEAACcQAAAAEOd8p5/8ShW4KCtfZOI+vHMkRjkL3shIXftUsHFq4hU6HA5h5pvWfivawv0r/hwfJQ==", null, "8bf28c32-e5fb-4921-98ef-0c98c1b9c7b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PlayerId", "SecurityStamp" },
                values: new object[] { "b68ffe33-112d-410a-a84f-75581bed6e68", "AQAAAAEAACcQAAAAEGbM3Jw+tJKVI6QBGmVyCkaB1tCXMtChGGiZYkc4+gCvOCAExLxl3rM4/EGS3EIQfQ==", null, "fbcdb052-f0f1-4130-89a7-6ad2c8e7210d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PlayerId", "SecurityStamp" },
                values: new object[] { "50268bfa-7534-4954-9394-a92e1219bbf4", "AQAAAAEAACcQAAAAEJqd2wGocVcJzY3FFcpMX2V3qHOEnlULS6AIEDMQ2S/rrMn1VsjxLDjMpVTCVU3S1A==", null, "aee70854-d122-4c13-9c01-a1ea8ca29b0b" });

            migrationBuilder.UpdateData(
                table: "FieldOwners",
                keyColumn: "Id",
                keyValue: new Guid("568302c8-4561-4e7d-a796-1ae35b530c5f"),
                columns: new[] { "CompanyName", "FirstName", "LastName" },
                values: new object[] { "BestCompany", "Georgi", "Georgiev" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "Position", "UserId" },
                values: new object[] { new Guid("6080ef67-c8d7-49f2-8639-f8c0779b50d8"), "Sofia", false, "Player", 1, new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: new Guid("9532ac14-2efc-4345-aff7-2cbae927886b"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("6080ef67-c8d7-49f2-8639-f8c0779b50d8"));

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "FieldOwners");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FieldOwners");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FieldOwners");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FieldOwners");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Administrators");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Administrators");

            migrationBuilder.RenameColumn(
                name: "FieldOwnerId",
                table: "AspNetUsers",
                newName: "OwnerId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Teams",
                type: "bit",
                nullable: false,
                comment: "Indicate if this team is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this administrator profile is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Players",
                type: "bit",
                nullable: false,
                comment: "Indicate if this player profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this administrator profile is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Messages",
                type: "bit",
                nullable: false,
                comment: "Indicate if this message is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this administrator profile is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Goals",
                type: "bit",
                nullable: false,
                comment: "Indicate if this goal is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this administrator profile is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Games",
                type: "bit",
                nullable: false,
                comment: "Indicate if this game is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this administrator profile is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Fields",
                type: "bit",
                nullable: false,
                comment: "Indicate if this field record is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this administrator profile is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "FieldOwners",
                type: "bit",
                nullable: false,
                comment: "Indicate if this field owner profile is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this administrator profile is considered deleted");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Bans",
                type: "bit",
                nullable: false,
                comment: "Indicate if this ban is considered deleted",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldComment: "Indicate if this administrator profile is considered deleted");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The identifier of the player profile, that is owned by this user.",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "The identifier of the player profile, that is owned by this user.");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PlayerId", "SecurityStamp" },
                values: new object[] { "5e5adc9b-acd1-4e60-aec5-b239dfe6bfde", "AQAAAAEAACcQAAAAEJQmjvvKWxY5bP4qLKrfqj/MDvhgByleatZ0jZnrOQA4Y4vYcYg6uCQfMcowshipHw==", new Guid("00000000-0000-0000-0000-000000000000"), "05154771-a684-42be-8436-6fa63aba885e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PlayerId", "SecurityStamp" },
                values: new object[] { "9e5c40e0-020c-475c-ac98-8e886f97bd1d", "AQAAAAEAACcQAAAAEJrvyAarjdqRYMgKN5k0h7dSqsajMcCAYtA5T9iSnIwjPwlBsx/F1kMr+VegJ1oYmg==", new Guid("00000000-0000-0000-0000-000000000000"), "a4a6941f-f7cb-4393-a0b3-b86fcbdbae62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PlayerId", "SecurityStamp" },
                values: new object[] { "3665dbe6-87d1-4484-9858-5559926bb9f0", "AQAAAAEAACcQAAAAEOwrbmQHINgr7aqRubS30ejeTiBcqTiMfwLLwil5elO4VUKs6Wsfth3nwSb5jVsclA==", new Guid("00000000-0000-0000-0000-000000000000"), "c5560891-72e1-4046-8c1d-030cbfc0d2a8" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "Position", "UserId" },
                values: new object[] { new Guid("899825ad-19d1-4d22-be3b-e562dbcd12f3"), "Sofia", false, "Player", 1, new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });
        }
    }
}
