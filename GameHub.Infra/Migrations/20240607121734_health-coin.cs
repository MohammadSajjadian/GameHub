using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameHub.Infra.Migrations
{
    /// <inheritdoc />
    public partial class healthcoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Coin",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Health",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coin",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Health",
                table: "AspNetUsers");
        }
    }
}
