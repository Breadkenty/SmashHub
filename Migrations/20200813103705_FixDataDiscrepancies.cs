using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Migrations
{
    public partial class FixDataDiscrepancies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
              table: "Characters",
              keyColumn: "VariableName",
              keyValue: "Mii"  
            );
            migrationBuilder.DeleteData(
              table: "Characters",
              keyColumn: "VariableName",
              keyValue: "PokemonTrainer"  
            );

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Squirtle"
            );
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Ivysaur"
            );
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "Charizard"
            );

            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Squirtle", "Squirtle", 0, 33});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Ivysaur", "Ivysaur", 60, 34});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Charizard", "Charizard", 25, 35});

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MiiBrawler"
            );
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MiiSwordfighter"
            );
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "MiiGunner"
            );
            
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Mii Brawler", "MiiBrawler", 10, 51});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Mii Swordfighter", "MiiSwordfighter", 10, 52});
            migrationBuilder.InsertData(
                table: "Characters", 
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Mii Gunner", "MiiGunner", 10, 53});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
