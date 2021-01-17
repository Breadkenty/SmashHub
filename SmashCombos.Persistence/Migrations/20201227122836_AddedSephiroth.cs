using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashCombos.Persistence.Migrations
{
    public partial class AddedSephiroth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new string[]{"Name", "VariableName", "YPosition", "ReleaseOrder"},
                values: new object[]{"Sephiroth", "Sephiroth", 10, 78.0});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Name",
                keyValue: "Sephiroth");
        }
    }
}
