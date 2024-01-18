using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopAPI.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationRaceEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RaceId",
                table: "Races",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Races",
                newName: "RaceId");
        }
    }
}
