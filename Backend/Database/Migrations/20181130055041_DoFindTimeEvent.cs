using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyImIn.Database.Migrations
{
    public partial class DoFindTimeEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DoFindTime",
                table: "Events",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoFindTime",
                table: "Events");
        }
    }
}
