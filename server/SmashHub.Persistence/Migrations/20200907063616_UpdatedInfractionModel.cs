using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmashHub.Persistence.Migrations
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
