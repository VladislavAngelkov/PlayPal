using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdministratorId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the administrator profile, that is owned by this user.");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Indicate if this player profile is considered deleted");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                comment: "The identifier of the field owner profile, that is owned by this user.");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "The identifier of the player profile, that is owned by this user.");

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the Administrator profile"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The identifier of the user, owning the administrator profile"),
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
                name: "FieldOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Field owner's identifier."),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The identifier of the user, owning owner's profile"),
                    ContactAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Field owner's physical address for official correspondence"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this field owner profile is considered deleted")
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
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The identifier of the user, that has send the message"),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The identifier of the user, that has received the message"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "The content of the message"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this message is considered deleted")
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
                    Position = table.Column<int>(type: "int", nullable: false, comment: "The preffered position of the player."),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "The identifier of the user, owning player's profile"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this player profile is considered deleted")
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
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Field's identifier."),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "The name of the city where the field is located"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The address of the field (district, street, number)"),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the field owner"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this field record is considered deleted")
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this ban is considered deleted")
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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this game is considered deleted")
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
                name: "AwayTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the team"),
                    GameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the game, in which the team played"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this team is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwayTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwayTeams_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The goal identifier"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the player, who scored the goal"),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the game in which the goal was scored"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this goal is considered deleted")
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
                name: "HomeTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the team"),
                    GameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the game, in which the team played"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this team is considered deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeTeams_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "PlayersAwayTeams",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the player from the team"),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the team of the player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersAwayTeams", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_PlayersAwayTeams_AwayTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "AwayTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayersAwayTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayersHomeTeams",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the player from the team"),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the team of the player")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersHomeTeams", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_PlayersHomeTeams_HomeTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "HomeTeams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayersHomeTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AwayTeams_GameID",
                table: "AwayTeams",
                column: "GameID",
                unique: true);

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
                name: "IX_HomeTeams_GameID",
                table: "HomeTeams",
                column: "GameID",
                unique: true);

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
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayersAwayTeams_TeamId",
                table: "PlayersAwayTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersHomeTeams_TeamId",
                table: "PlayersHomeTeams",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PendingPlayersGames");

            migrationBuilder.DropTable(
                name: "PlayersAwayTeams");

            migrationBuilder.DropTable(
                name: "PlayersHomeTeams");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "AwayTeams");

            migrationBuilder.DropTable(
                name: "HomeTeams");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "FieldOwners");

            migrationBuilder.DropColumn(
                name: "AdministratorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "AspNetUsers");
        }
    }
}
