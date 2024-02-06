using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEG_api.Migrations
{
    /// <inheritdoc />
    public partial class Match_UpdateNulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Countries_CountryId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CountryId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Countries");
        }
    }
}
