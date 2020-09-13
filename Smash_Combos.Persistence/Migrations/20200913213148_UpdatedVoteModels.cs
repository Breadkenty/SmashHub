using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Persistence.Migrations
{
    public partial class UpdatedVoteModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CommentVotes_CommentId",
                table: "CommentVotes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentVotes_UserId",
                table: "CommentVotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboVotes_ComboId",
                table: "ComboVotes",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_ComboVotes_UserId",
                table: "ComboVotes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboVotes_Users_UserId",
                table: "ComboVotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentVotes_Users_UserId",
                table: "CommentVotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboVotes_Users_UserId",
                table: "ComboVotes");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentVotes_Users_UserId",
                table: "CommentVotes");

            migrationBuilder.DropIndex(
                name: "IX_CommentVotes_CommentId",
                table: "CommentVotes");

            migrationBuilder.DropIndex(
                name: "IX_CommentVotes_UserId",
                table: "CommentVotes");

            migrationBuilder.DropIndex(
                name: "IX_ComboVotes_ComboId",
                table: "ComboVotes");

            migrationBuilder.DropIndex(
                name: "IX_ComboVotes_UserId",
                table: "ComboVotes");
        }
    }
}
