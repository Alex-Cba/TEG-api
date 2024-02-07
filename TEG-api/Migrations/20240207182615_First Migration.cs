using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TEG_api.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TableName = table.Column<string>(type: "text", nullable: false),
                    RecordId = table.Column<string>(type: "text", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbHistories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    Faces = table.Column<int>(type: "integer", nullable: false),
                    Probability = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DifficultyType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ChangesInGame = table.Column<int>(type: "integer", nullable: false),
                    NumberOfDices = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    DiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_Dices_DiceId",
                        column: x => x.DiceId,
                        principalTable: "Dices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ValueOfTroops = table.Column<int>(type: "integer", nullable: false),
                    MapId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Continents_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MatchConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConfigurationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchConfigs_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Troops = table.Column<int>(type: "integer", nullable: false),
                    ContinentId = table.Column<int>(type: "integer", nullable: false),
                    OwnerID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Players_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matchs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDateUTC = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    SaveDateUTC = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    EndDateUTC = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    MatchStatus = table.Column<string>(type: "text", nullable: false),
                    Winner = table.Column<string>(type: "text", nullable: false),
                    MapId = table.Column<int>(type: "integer", nullable: false),
                    MatchConfigId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matchs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matchs_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matchs_MatchConfigs_MatchConfigId",
                        column: x => x.MatchConfigId,
                        principalTable: "MatchConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameSetup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<Guid>(type: "uuid", nullable: false),
                    MatchId = table.Column<Guid>(type: "uuid", nullable: false),
                    MissionId = table.Column<int>(type: "integer", nullable: false),
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameSetup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGameSetup_Matchs_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameSetup_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameSetup_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGameSetup_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_DiceId",
                table: "Configurations",
                column: "DiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Continents_MapId",
                table: "Continents",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentId",
                table: "Countries",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_PlayerId",
                table: "Countries",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_MatchConfigs_ConfigurationId",
                table: "MatchConfigs",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_MapId",
                table: "Matchs",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Matchs_MatchConfigId",
                table: "Matchs",
                column: "MatchConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameSetup_MatchId",
                table: "PlayerGameSetup",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameSetup_MissionId",
                table: "PlayerGameSetup",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameSetup_PlayerId",
                table: "PlayerGameSetup",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "PlayerGameSetup",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "Players_Users_UserId",
                table: "Players",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "DbHistories");

            migrationBuilder.DropTable(
                name: "PlayerGameSetup");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "Matchs");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "MatchConfigs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "Dices");
        }
    }
}
