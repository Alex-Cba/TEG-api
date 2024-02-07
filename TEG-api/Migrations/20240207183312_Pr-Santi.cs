using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEG_api.Migrations
{
    /// <inheritdoc />
    public partial class PrSanti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matchs_Maps_MapId",
                table: "Matchs");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "Matchs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Maps",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Countries",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CountryId",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Countries_CountryId",
                table: "Countries",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_Maps_MapId",
                table: "Matchs",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Countries_CountryId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Matchs_Maps_MapId",
                table: "Matchs");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CountryId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Countries");

            migrationBuilder.AlterColumn<int>(
                name: "MapId",
                table: "Matchs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Matchs_Maps_MapId",
                table: "Matchs",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
