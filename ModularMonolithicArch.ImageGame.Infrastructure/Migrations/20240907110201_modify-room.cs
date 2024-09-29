using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModularMonolithicArch.ImageGame.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyroom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorUserName",
                schema: "imageGame",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GuestId",
                schema: "imageGame",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatorUserName",
                schema: "imageGame",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "GuestId",
                schema: "imageGame",
                table: "Rooms");
        }
    }
}
