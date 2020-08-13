using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Migrations
{
    public partial class AddedCharacterReleaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ReleaseOrder",
                table: "Characters",
                nullable: false,
                defaultValue: 0m);
            
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Mario",
                column: "ReleaseOrder",
                value: 1
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "DonkeyKong",
                column: "ReleaseOrder",
                value: 2
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Link",
                column: "ReleaseOrder",
                value: 3
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Samus",
                column: "ReleaseOrder",
                value: 4
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "DarkSamus",
                column: "ReleaseOrder",
                value: 4.5
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Yoshi",
                column: "ReleaseOrder",
                value: 5
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Kirby",
                column: "ReleaseOrder",
                value: 6
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Fox",
                column: "ReleaseOrder",
                value: 7
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Pikachu",
                column: "ReleaseOrder",
                value: 8
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Luigi",
                column: "ReleaseOrder",
                value: 9
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Ness",
                column: "ReleaseOrder",
                value: 10
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "CaptainFalcon",
                column: "ReleaseOrder",
                value: 11
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Jigglypuff",
                column: "ReleaseOrder",
                value: 12
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Peach",
                column: "ReleaseOrder",
                value: 13
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Daisy",
                column: "ReleaseOrder",
                value: 13.5
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Bowser",
                column: "ReleaseOrder",
                value: 14
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "IceClimbers",
                column: "ReleaseOrder",
                value: 15
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Sheik",
                column: "ReleaseOrder",
                value: 16
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Zelda",
                column: "ReleaseOrder",
                value: 17
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "DrMario",
                column: "ReleaseOrder",
                value: 18
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Pichu",
                column: "ReleaseOrder",
                value: 19
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Falco",
                column: "ReleaseOrder",
                value: 20
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Marth",
                column: "ReleaseOrder",
                value: 21
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Lucina",
                column: "ReleaseOrder",
                value: 21.5
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "YoungLink",
                column: "ReleaseOrder",
                value: 22
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Ganondorf",
                column: "ReleaseOrder",
                value: 23
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Mewtwo",
                column: "ReleaseOrder",
                value: 24
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Roy",
                column: "ReleaseOrder",
                value: 25
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Chrom",
                column: "ReleaseOrder",
                value: 25.5
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MrGameAndWatch",
                column: "ReleaseOrder",
                value: 26
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MetaKnight",
                column: "ReleaseOrder",
                value: 27
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Pit",
                column: "ReleaseOrder",
                value: 28
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "DarkPit",
                column: "ReleaseOrder",
                value: 28.5
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "ZeroSuitSamus",
                column: "ReleaseOrder",
                value: 29
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Wario",
                column: "ReleaseOrder",
                value: 30
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Snake",
                column: "ReleaseOrder",
                value: 31
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Ike",
                column: "ReleaseOrder",
                value: 32
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Squirtle",
                column: "ReleaseOrder",
                value: 33
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Ivysaur",
                column: "ReleaseOrder",
                value: 34
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Charizard",
                column: "ReleaseOrder",
                value: 35
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "DiddyKong",
                column: "ReleaseOrder",
                value: 36
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Lucas",
                column: "ReleaseOrder",
                value: 37
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Sonic",
                column: "ReleaseOrder",
                value: 38
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "KingDedede",
                column: "ReleaseOrder",
                value: 39
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Olimar",
                column: "ReleaseOrder",
                value: 40
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Lucario",
                column: "ReleaseOrder",
                value: 41
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "ROB",
                column: "ReleaseOrder",
                value: 42
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "ToonLink",
                column: "ReleaseOrder",
                value: 43
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Wolf",
                column: "ReleaseOrder",
                value: 44
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Villager",
                column: "ReleaseOrder",
                value: 45
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MegaMan",
                column: "ReleaseOrder",
                value: 46
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "WiiFitTrainer",
                column: "ReleaseOrder",
                value: 47
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "RosalinaAndLuma",
                column: "ReleaseOrder",
                value: 48
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "LittleMac",
                column: "ReleaseOrder",
                value: 49
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Greninja",
                column: "ReleaseOrder",
                value: 50
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MiiBrawler",
                column: "ReleaseOrder",
                value: 51
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MiiSwordfighter",
                column: "ReleaseOrder",
                value: 52
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MiiGunner",
                column: "ReleaseOrder",
                value: 53
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Palutena",
                column: "ReleaseOrder",
                value: 54
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "PacMan",
                column: "ReleaseOrder",
                value: 55
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Robin",
                column: "ReleaseOrder",
                value: 56
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Shulk",
                column: "ReleaseOrder",
                value: 57
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "BowserJr",
                column: "ReleaseOrder",
                value: 58
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "DuckHunt",
                column: "ReleaseOrder",
                value: 59
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Ryu",
                column: "ReleaseOrder",
                value: 60
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Ken",
                column: "ReleaseOrder",
                value: 60.5
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Cloud",
                column: "ReleaseOrder",
                value: 61
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Corrin",
                column: "ReleaseOrder",
                value: 62
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Bayonetta",
                column: "ReleaseOrder",
                value: 63
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Inkling",
                column: "ReleaseOrder",
                value: 64
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Ridley",
                column: "ReleaseOrder",
                value: 65
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Simon",
                column: "ReleaseOrder",
                value: 66
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Richter",
                column: "ReleaseOrder",
                value: 66.5
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "KingKRool",
                column: "ReleaseOrder",
                value: 67
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Isabelle",
                column: "ReleaseOrder",
                value: 68
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Incineroar",
                column: "ReleaseOrder",
                value: 69
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "PiranhaPlant",
                column: "ReleaseOrder",
                value: 70
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Joker",
                column: "ReleaseOrder",
                value: 71
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Hero",
                column: "ReleaseOrder",
                value: 72
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "BanjoAndKazooie",
                column: "ReleaseOrder",
                value: 73
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Terry",
                column: "ReleaseOrder",
                value: 74
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Byleth",
                column: "ReleaseOrder",
                value: 75
            );
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MinMin",
                column: "ReleaseOrder",
                value: 76
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseOrder",
                table: "Characters");
        }
    }
}
