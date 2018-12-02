using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyImIn.Database.Migrations
{
    public partial class FinderFieldsFromTo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "AppointmentFinders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));


            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "AppointmentFinders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "AppointmentFinders");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "AppointmentFinders");

        }
    }
}
