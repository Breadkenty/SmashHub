using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Persistence.Migrations
{
    public partial class AddedSteve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Steve", "Steve", 0, 77.0});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Name",
                keyValue: "Steve");
        }
    }
}
