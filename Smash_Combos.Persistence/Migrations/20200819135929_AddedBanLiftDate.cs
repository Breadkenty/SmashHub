using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Persistence.Migrations
{
    public partial class AddedBanLiftDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BanLiftDate",
                table: "Infractions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BanLiftDate",
                table: "Infractions");
        }
    }
}
