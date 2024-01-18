using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class PetEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Races",
                newName: "RaceId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pets",
                newName: "PetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Colors",
                newName: "ColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "Races",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "Pets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ColorId",
                table: "Colors",
                newName: "Id");
        }
    }
}
