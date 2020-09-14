using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Persistence.Migrations
{
    public partial class FixedDataDiscrepancies : Migration
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

            migrationBuilder.Sql(
                "DO " +
                "$do$ " +
                "BEGIN " +
                "IF NOT EXISTS (SELECT FROM \"Characters\" WHERE \"VariableName\" = 'Squirtle') THEN " +
                "INSERT INTO \"Characters\" (\"Name\", \"VariableName\", \"YPosition\", \"ReleaseOrder\") " +
                "VALUES('Squirtle', 'Squirtle', 0, 33); " +
                "END IF; " +
                "END " +
                "$do$"
            );
            migrationBuilder.Sql(
                "DO " +
                "$do$ " +
                "BEGIN " +
                "IF NOT EXISTS (SELECT FROM \"Characters\" WHERE \"VariableName\" = 'Ivysaur') THEN " +
                "INSERT INTO \"Characters\" (\"Name\", \"VariableName\", \"YPosition\", \"ReleaseOrder\") " +
                "VALUES('Ivysaur', 'Ivysaur', 60, 34); " +
                "END IF; " +
                "END " +
                "$do$"
            );
            migrationBuilder.Sql(
                "DO " +
                "$do$ " +
                "BEGIN " +
                "IF NOT EXISTS (SELECT FROM \"Characters\" WHERE \"VariableName\" = 'Charizard') THEN " +
                "INSERT INTO \"Characters\" (\"Name\", \"VariableName\", \"YPosition\", \"ReleaseOrder\") " +
                "VALUES('Charizard', 'Charizard', 25, 35); " +
                "END IF; " +
                "END " +
                "$do$"
            );

            migrationBuilder.Sql(
                "DO " +
                "$do$ " +
                "BEGIN " +
                "IF NOT EXISTS (SELECT FROM \"Characters\" WHERE \"VariableName\" = 'MiiBrawler') THEN " +
                "INSERT INTO \"Characters\" (\"Name\", \"VariableName\", \"YPosition\", \"ReleaseOrder\") " +
                "VALUES('Mii Brawler', 'MiiBrawler', 10, 51); " +
                "END IF; " +
                "END " +
                "$do$"
            );
            migrationBuilder.Sql(
                "DO " +
                "$do$ " +
                "BEGIN " +
                "IF NOT EXISTS (SELECT FROM \"Characters\" WHERE \"VariableName\" = 'MiiSwordfighter') THEN " +
                "INSERT INTO \"Characters\" (\"Name\", \"VariableName\", \"YPosition\", \"ReleaseOrder\") " +
                "VALUES('Mii Swordfighter', 'MiiSwordfighter', 10, 52); " +
                "END IF; " +
                "END " +
                "$do$"
            );
            migrationBuilder.Sql(
                "DO " +
                "$do$ " +
                "BEGIN " +
                "IF NOT EXISTS (SELECT FROM \"Characters\" WHERE \"VariableName\" = 'MiiGunner') THEN " +
                "INSERT INTO \"Characters\" (\"Name\", \"VariableName\", \"YPosition\", \"ReleaseOrder\") " +
                "VALUES('Mii Gunner', 'MiiGunner', 10, 53); " +
                "END IF; " +
                "END " +
                "$do$"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Pokemon Trainer", "PokemonTrainer", 5, 33});

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Mii", "Mii", 10, 51});

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
        }
    }
}
