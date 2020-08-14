using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Persistence.Migrations
{
    public partial class AddedVoteForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_ComboVotes_Combos_ComboId",
                table: "ComboVotes",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );

            migrationBuilder.AddForeignKey(
                name: "FK_CommentVotes_Comments_CommentId",
                table: "CommentVotes",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboVotes_Combos_ComboId",
                table: "ComboVotes"
            );
            migrationBuilder.DropForeignKey(
                name: "FK_CommentVotes_Comments_CommentId",
                table: "CommentVotes"
            );
        }
    }
}
