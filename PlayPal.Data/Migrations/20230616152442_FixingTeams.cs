using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayPal.Data.Migrations
{
    public partial class FixingTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersAwayTeams");

            migrationBuilder.DropTable(
                name: "PlayersHomeTeams");

            migrationBuilder.DropTable(
                name: "AwayTeams");

            migrationBuilder.DropTable(
                name: "HomeTeams");

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The indentifier of the team"),
                    HomeGameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the home game, in which the team played"),
                    AwayGameID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "The identifier of the away game, in which the team played"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, comment: "Indicate if this team is considered deleted")
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
                name: "PlayersTeams");

            migrationBuilder.DropTable(
                name: "Teams");

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
                name: "IX_AwayTeams_GameID",
                table: "AwayTeams",
                column: "GameID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeTeams_GameID",
                table: "HomeTeams",
                column: "GameID",
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
    }
}
