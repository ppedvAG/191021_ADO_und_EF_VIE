using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ppedv.ProjectAli.Data.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AircraftType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(maxLength: 4, nullable: false),
                    Model = table.Column<string>(maxLength: 200, nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 200, nullable: false),
                    WTC = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AircraftType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    LocInt = table.Column<string>(fixedLength: true, maxLength: 4, nullable: false),
                    Decode = table.Column<string>(maxLength: 200, nullable: false),
                    Iata = table.Column<string>(fixedLength: true, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    DepartureID = table.Column<int>(nullable: true),
                    DestinationID = table.Column<int>(nullable: true),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    AircraftID = table.Column<string>(maxLength: 7, nullable: false),
                    AircraftTypeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flight_AircraftType_AircraftTypeID",
                        column: x => x.AircraftTypeID,
                        principalTable: "AircraftType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_DepartureID",
                        column: x => x.DepartureID,
                        principalTable: "Airport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airport_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Airport",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AircraftTypeID",
                table: "Flight",
                column: "AircraftTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureID",
                table: "Flight",
                column: "DepartureID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationID",
                table: "Flight",
                column: "DestinationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "AircraftType");

            migrationBuilder.DropTable(
                name: "Airport");
        }
    }
}
