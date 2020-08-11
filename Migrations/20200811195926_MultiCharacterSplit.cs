using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Migrations
{
    public partial class MultiCharacterSplit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ReleaseOrder",
                table: "Characters",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseOrder",
                table: "Characters");
        }
    }
}
