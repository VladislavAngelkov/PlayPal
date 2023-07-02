using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class RebuildingTheDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "The identifier of the player profile, that is owned by this user."),
                    AdministratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "The identifier of the administrator profile, that is owned by this user."),
                    FieldOwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "The identifier of the field owner profile, that is owned by this user."),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this player profile is considered deleted"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the position"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The name of the postion"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the Administrator profile"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, owning the administrator profile"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Field owner's identifier."),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the company that owns the field"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "The first name of the representive of the company that owns the field"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The last name of the representive of the company that owns the field"),
                    Title = table.Column<int>(type: "int", nullable: false, comment: "The title of the representive"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, owning owner's profile"),
                    ContactAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Field owner's physical address for official correspondence"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldOwners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Message identifier"),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, that has send the message"),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, that has received the message"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The content of the message"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Player's identifier."),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "The name, that player will be seen with by other users."),
                    CurrentCity = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The current location of the player. Its used for finding nearby games."),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the preffered position of the player."),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the user, owning player's profile"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Field's identifier."),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The name of the city where the field is located"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The address of the field (district, street, number)"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the field owner"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_FieldOwners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "FieldOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the ban"),
                    AdministratorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the administrator, who issued th ban"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the player, who has been banned"),
                    Reason = table.Column<int>(type: "int", nullable: false, comment: "The reason for the ban"),
                    BannedTo = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "The date and hour, when the ban expires"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bans_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bans_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Game identifier"),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the player who has created the game"),
                    FieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the field, where the game is played"),
                    StartingTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Mark the starting time of the game"),
                    EndingTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Mark the ending time of the game"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Players_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The goal identifier"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the player, who scored the goal"),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the game in which the goal was scored"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goals_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Goals_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PendingPlayersGames",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the pending player"),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the pending game")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingPlayersGames", x => new { x.PlayerId, x.GameId });
                    table.ForeignKey(
                        name: "FK_PendingPlayersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PendingPlayersGames_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the team"),
                    HomeGameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the home game, in which the team played"),
                    AwayGameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the away game, in which the team played"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this administrator profile is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Games_AwayGameID",
                        column: x => x.AwayGameID,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teams_Games_HomeGameID",
                        column: x => x.HomeGameID,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayersTeams",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the player from the team"),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the team of the player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersTeams", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_PlayersTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayersTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"), "d2830678-d5ad-4a92-9d59-d55f0abe6849", "Player", "PLAYER" },
                    { new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"), "04fa9523-367a-4148-bf3e-56beeaa3537a", "FieldOwner", "FIELDOWNER" },
                    { new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"), "6c1138e9-7af4-4675-8a17-4e665e6d7487", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdministratorId", "ConcurrencyStamp", "Email", "EmailConfirmed", "FieldOwnerId", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d"), 0, null, "d444fd6e-12b7-4df2-83a4-ea627078d26f", "FieldOwner@test.com", false, null, false, false, null, "FIELDOWNER@TEST.COM", "FIELDOWNER@TEST.COM", "AQAAAAEAACcQAAAAEMOAgLyWGZqEBun/YQBJX3a9lIFU5FMmADuCY2SuOcsx/o34SOvfA2trZ6WXYci8gA==", null, false, null, "f7fcda59-e271-4f1b-8723-4163568cd747", false, "FieldOwner@test.com" },
                    { new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d"), 0, null, "41b1d6e0-cd25-49bd-acbe-303095f04901", "Administrator@test.com", false, null, false, false, null, "ADMINISTRATOR@TEST.COM", "ADMINISTRATOR@TEST.COM", "AQAAAAEAACcQAAAAEBXeCJbB/0Cq5XoGUIh7YKrQpdZMB30tgTwAzg6MKkLcj3KQOdkxfGIrwOHdkM5bUA==", null, false, null, "7a6196b1-af70-49b6-846b-018b95ad166d", false, "Administrator@test.com" },
                    { new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d"), 0, null, "f8981aff-ee79-40b0-b362-bb90886718b3", "Player@test.com", false, null, false, false, null, "PLAYER@TEST.COM", "PLAYER@TEST.COM", "AQAAAAEAACcQAAAAEM1shknMLzzl5MTd3KUOaIb/iHJ8Rqj/tqECaEyFEEOqGvvrwr3U8y1SxwLhD171xg==", null, false, null, "18b9089e-1e9a-419f-8831-0c1706c2ea5e", false, "Player@test.com" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("5a491d86-fc04-4359-aef9-feca2630e6bf"), false, "GoalKeeper" },
                    { new Guid("6b6e1b10-baac-4f32-b276-21d5de82ac52"), false, "FieldPlayer" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "UserId" },
                values: new object[] { new Guid("34e53562-17e0-4e2d-84fb-7aa4ec4e88f3"), "Ivan", false, "Ivanov", new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c3caf211-8a76-4415-a74a-6b7f0a0b9d50"), new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") },
                    { new Guid("f5356275-13f4-4d7c-8172-bbf054707e2f"), new Guid("9a641cdf-8c28-485f-b22a-3603c6df7a3d") },
                    { new Guid("b333df2f-222c-4768-a9f5-0368b93aea47"), new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") }
                });

            migrationBuilder.InsertData(
                table: "FieldOwners",
                columns: new[] { "Id", "CompanyName", "ContactAddress", "FirstName", "IsDeleted", "LastName", "Title", "UserId" },
                values: new object[] { new Guid("568302c8-4561-4e7d-a796-1ae35b530c5f"), "BestCompany", "Sofia, str. Vasil Levski #11", "Georgi", false, "Georgiev", 0, new Guid("84b6df4e-b349-495e-a9e1-8541de1f2e2d") });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "CurrentCity", "IsDeleted", "Name", "PositionId", "UserId" },
                values: new object[] { new Guid("8d46b487-1b10-4de2-89b5-2beac2c6428f"), "Sofia", false, "Player", new Guid("5a491d86-fc04-4359-aef9-feca2630e6bf"), new Guid("ec70c161-fc76-4b29-b3dc-03fdd605bf0d") });

            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "Address", "City", "IsDeleted", "OwnerId" },
                values: new object[] { new Guid("06921ef3-e09a-456d-92ef-aada394af8bb"), "str. Hristo Botev 36", "Sofia", false, new Guid("568302c8-4561-4e7d-a796-1ae35b530c5f") });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bans_AdministratorId",
                table: "Bans",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bans_PlayerId",
                table: "Bans",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldOwners_UserId",
                table: "FieldOwners",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fields_OwnerId",
                table: "Fields",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CreatorId",
                table: "Games",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_FieldId",
                table: "Games",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_GameId",
                table: "Goals",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_PlayerId",
                table: "Goals",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PendingPlayersGames_GameId",
                table: "PendingPlayersGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PositionId",
                table: "Players",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTeams_TeamId",
                table: "PlayersTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AwayGameID",
                table: "Teams",
                column: "AwayGameID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HomeGameID",
                table: "Teams",
                column: "HomeGameID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PendingPlayersGames");

            migrationBuilder.DropTable(
                name: "PlayersTeams");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "FieldOwners");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
