using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Smash_Combos.Migrations
{
    public partial class AllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    VariableName = table.Column<string>(nullable: true),
                    YPosition = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComboVotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    ComboId = table.Column<int>(nullable: false),
                    upOrDown = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboVotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommentVotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    CommentId = table.Column<int>(nullable: false),
                    upOrDown = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentVotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Admin = table.Column<bool>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    HashedPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    VideoId = table.Column<string>(nullable: false),
                    VideoStartTime = table.Column<int>(nullable: false),
                    VideoEndTime = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    ComboId = table.Column<int>(nullable: false),
                    DatePosted = table.Column<DateTime>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    NetVote = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combos_CharacterId",
                table: "Combos",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ComboId",
                table: "Comments",
                column: "ComboId");

            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Mario", "Mario", 30});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Donkey Kong", "DonkeyKong", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Link", "Link", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Samus", "Samus", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Dark Samus", "DarkSamus", 4.5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Yoshi", "Yoshi", 5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Kirby", "Kirby", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Fox", "Fox", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Pikachu", "Pikachu", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Luigi", "Luigi", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Ness", "Ness", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Captain Falcon", "CaptainFalcon", 5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Jigglypuff", "Jigglypuff", 35});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Peach", "Peach", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Daisy", "Daisy", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Bowser", "Bowser", 40});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Ice Climbers", "IceClimbers", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Sheik", "Sheik", 5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Zelda", "Zelda", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Dr. Mario", "DrMario", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Pichu", "Pichu", 40});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Falco", "Falco", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Marth", "Marth", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Lucina", "Lucina", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Young Link", "YoungLink", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Ganondorf", "Ganondorf", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Mewtwo", "Mewtwo", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Roy", "Roy", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Chrom", "Chrom", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Mr. Game & Watch", "MrGameAndWatch", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Meta Knight", "MetaKnight", 50});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Pit", "Pit", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Dark Pit", "DarkPit", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Zero Suit Samus", "ZeroSuitSamus", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Wario", "Wario", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Snake", "Snake", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Ike", "Ike", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Squirtle", "Squirtle", 0});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Ivysaur", "Ivysaur", 60});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Charizard", "Charizard", 25});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Diddy Kong", "DiddyKong", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Lucas", "Lucas", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Sonic", "Sonic", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"King Dedede", "KingDedede", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Olimar", "Olimar", 50});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Lucario", "Lucario", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"R.O.B.", "ROB", 5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Toon Link", "ToonLink", 25});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Wolf", "Wolf", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Villager", "Villager", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Mega Man", "MegaMan", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Wii Fit Trainer", "WiiFitTrainer", 0});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Rosalina & Luma", "RosalinaAndLuma", 5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Little Mac", "LittleMac", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Greninja", "Greninja", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Mii Brawler", "MiiBrawler", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Mii Swordfighter", "MiiSwordfighter", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Mii Gunner", "MiiGunner", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Palutena", "Palutena", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Pac-Man", "PacMan", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Robin", "Robin", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Shulk", "Shulk", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Bowser Jr.", "BowserJr", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Duck Hunt", "DuckHunt", 60});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Ryu", "Ryu", 13});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Ken", "Ken", 13});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Cloud", "Cloud", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Corrin", "Corrin", 5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Bayonetta", "Bayonetta", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Inkling", "Inkling", 20});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Ridley", "Ridley", 40});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Simon", "Simon", 5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Richter", "Richter", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"King K. Rool", "KingKRool", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Isabelle", "Isabelle", 30});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Incineroar", "Incineroar", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Piranha Plant", "PiranhaPlant", 15});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Joker", "Joker", 45});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Hero", "Hero", 5});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Banjo & Kazooie", "BanjoAndKazooie", 50});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Terry", "Terry", 10});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Byleth", "Byleth", 3});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition"},
                values: new object[]{"Min Min", "MinMin", 23});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboVotes");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "CommentVotes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
