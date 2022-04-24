using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashHub.Persistence.Migrations
{
    public partial class UpdatedVoteModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CommentVotes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "CommentVotes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpvote",
                table: "CommentVotes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CommentVotes",
                keyColumn: "upOrDown",
                keyValue: "upvote",
                column: "IsUpvote",
                value: true
                );

            migrationBuilder.UpdateData(
                table: "CommentVotes",
                keyColumn: "upOrDown",
                keyValue: "downvote",
                column: "IsUpvote",
                value: false
                );

            migrationBuilder.DropColumn(
                name: "upOrDown",
                table: "CommentVotes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ComboVotes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ComboId",
                table: "ComboVotes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<bool>(
                name: "IsUpvote",
                table: "ComboVotes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ComboVotes",
                keyColumn: "upOrDown",
                keyValue: "upvote",
                column: "IsUpvote",
                value: true
                );

            migrationBuilder.UpdateData(
                table: "ComboVotes",
                keyColumn: "upOrDown",
                keyValue: "downvote",
                column: "IsUpvote",
                value: false
                );

            migrationBuilder.DropColumn(
                name: "upOrDown",
                table: "ComboVotes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CommentVotes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "CommentVotes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "upOrDown",
                table: "CommentVotes",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CommentVotes",
                keyColumn: "IsUpvote",
                keyValue: true,
                column: "upOrDown",
                value: "upvote"
                );

            migrationBuilder.UpdateData(
                table: "CommentVotes",
                keyColumn: "IsUpvote",
                keyValue: false,
                column: "upOrDown",
                value: "downvote"
                );

            migrationBuilder.DropColumn(
                name: "IsUpvote",
                table: "CommentVotes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ComboVotes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComboId",
                table: "ComboVotes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "upOrDown",
                table: "ComboVotes",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ComboVotes",
                keyColumn: "IsUpvote",
                keyValue: true,
                column: "upOrDown",
                value: "upvote"
                );

            migrationBuilder.UpdateData(
                table: "ComboVotes",
                keyColumn: "IsUpvote",
                keyValue: false,
                column: "upOrDown",
                value: "downvote"
                );

            migrationBuilder.DropColumn(
                name: "IsUpvote",
                table: "ComboVotes");
        }
    }
}
