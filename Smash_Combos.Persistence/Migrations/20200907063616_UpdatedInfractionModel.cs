using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smash_Combos.Persistence.Migrations
{
    public partial class UpdatedInfractionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Infractions\"" +
                " RENAME COLUMN \"BanLiftDate\" TO \"DismissDate\"");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Infractions\"" +
                " RENAME COLUMN \"DismissDate\" TO \"BanLiftDate\"");
        }
    }
}
