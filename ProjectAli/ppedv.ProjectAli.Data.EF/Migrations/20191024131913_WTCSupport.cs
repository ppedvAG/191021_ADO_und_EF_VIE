using Microsoft.EntityFrameworkCore.Migrations;

namespace ppedv.ProjectAli.Data.EF.Migrations
{
    public partial class WTCSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupportedWTC",
                table: "Airport",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupportedWTC",
                table: "Airport");
        }
    }
}
