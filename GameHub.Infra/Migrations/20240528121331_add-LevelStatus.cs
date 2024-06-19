using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameHub.Infra.Migrations
{
    /// <inheritdoc />
    public partial class addLevelStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelStatus",
                table: "Levels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelStatus",
                table: "Levels");
        }
    }
}
