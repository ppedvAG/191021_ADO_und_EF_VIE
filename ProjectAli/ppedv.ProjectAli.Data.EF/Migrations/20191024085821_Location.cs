using Microsoft.EntityFrameworkCore.Migrations;

namespace ppedv.ProjectAli.Data.EF.Migrations
{
    public partial class Location : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AircraftID",
                table: "Flight",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AddColumn<double>(
                name: "Elevation",
                table: "Airport",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Airport",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Airport",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Elevation",
                table: "Airport");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Airport");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Airport");

            migrationBuilder.AlterColumn<string>(
                name: "AircraftID",
                table: "Flight",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
