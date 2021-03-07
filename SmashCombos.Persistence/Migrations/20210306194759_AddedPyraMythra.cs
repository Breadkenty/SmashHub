using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashCombos.Persistence.Migrations
{
    public partial class AddedPyraMythra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Characters",
                columns: new string[] { "Name", "VariableName", "YPosition", "ReleaseOrder" },
                values: new object[] { "Pyra/Mythra", "PyraMythra", 30, 79.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "VariableName",
                keyValue: "PyraMythra");
        }
    }
}
