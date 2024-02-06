using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TEG_api.Migrations
{
    /// <inheritdoc />
    public partial class Models_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Dices",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "DiceType",
                table: "Dices",
                newName: "Faces");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Maps",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Maps");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Dices",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "Faces",
                table: "Dices",
                newName: "DiceType");
        }
    }
}
