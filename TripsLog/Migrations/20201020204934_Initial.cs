using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TripsLog.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Accommodation = table.Column<string>(nullable: true),
                    AccommodationPhone = table.Column<string>(nullable: true),
                    AccommodationEmail = table.Column<string>(nullable: true),
                    ThingToDo1 = table.Column<string>(nullable: true),
                    ThingToDo2 = table.Column<string>(nullable: true),
                    ThingToDo3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 1, null, null, null, "New York", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
