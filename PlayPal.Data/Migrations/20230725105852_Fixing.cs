using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class Fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"),
                column: "ConcurrencyStamp",
                value: "b1178909-b35e-435e-8f5e-ae59f1d77d74");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"),
                column: "ConcurrencyStamp",
                value: "73483d44-fa76-4b9a-8257-01ad5b338bf7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"),
                column: "ConcurrencyStamp",
                value: "6635b683-6cb2-4528-b13f-4a6af64f2014");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8999b8dd-9175-4f54-9f6d-9c8e25c18090", "AQAAAAEAACcQAAAAEJ4M5hELEoitwDCMl+uaR3OJL2uzG33VfQFWdh0PG8GybEElnX2JJ8pp4kNkYvUSaA==", "c7af1883-16e8-4043-8954-fa81ea94a2d9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09db1354-cb4c-4664-b284-48dd2236caba", "AQAAAAEAACcQAAAAEPhtJhlSK3WESfY6EGtL6rxD9mvPtIZb/QepUerqOONb3aTVraIi4KPLTvgDzExMmQ==", "8b724249-6030-42c2-88c5-79de2eed88dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "632326d7-0d7b-4032-9d00-5e44360fd44d", "AQAAAAEAACcQAAAAEDfTFQaVDq54+9bhHxvzllSGGotzygveOt5PW8hAVinVDNX/YHzqLKlcCaKF43glrw==", "0e0d2585-de0c-49f4-ad7a-871e7aac95ac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
