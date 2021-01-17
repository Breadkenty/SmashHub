using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashCombos.Persistence.Migrations
{
    public partial class AddedPasswordCriteria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PasswordMeetsCriteria",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Combos_UserId",
                table: "Combos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Combos_Users_UserId",
                table: "Combos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Combos_Users_UserId",
                table: "Combos");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Combos_UserId",
                table: "Combos");

            migrationBuilder.DropColumn(
                name: "PasswordMeetsCriteria",
                table: "Users");
        }
    }
}
