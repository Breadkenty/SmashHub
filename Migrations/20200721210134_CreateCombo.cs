using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Smash_Combos.Migrations
{
    public partial class CreateCombo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CharacterId = table.Column<int>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    VideoId = table.Column<string>(nullable: false),
                    ComboInput = table.Column<string>(nullable: false),
                    TrueCombo = table.Column<bool>(nullable: false),
                    Difficulty = table.Column<string>(nullable: false),
                    Damage = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    NetVote = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Combos_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combos_CharacterId",
                table: "Combos",
                column: "CharacterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combos");
        }
    }
}
