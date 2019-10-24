using Microsoft.EntityFrameworkCore.Migrations;

namespace ppedv.ProjectAli.Data.EF.Migrations
{
    public partial class ConfigNeu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AircraftID",
                table: "Flight",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AircraftID",
                table: "Flight",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 7);
        }
    }
}
