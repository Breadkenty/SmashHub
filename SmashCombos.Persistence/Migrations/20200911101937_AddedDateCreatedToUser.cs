using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashCombos.Persistence.Migrations
{
    public partial class AddedDateCreatedToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                nullable: false,
                defaultValue: DateTime.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Users");
        }
    }
}
