using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Migrations
{
    public partial class AddedVideoStartAndEndTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VideoEndTime",
                table: "Combos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideoStartTime",
                table: "Combos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoEndTime",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "VideoStartTime",
                table: "Combos");
        }
    }
}
