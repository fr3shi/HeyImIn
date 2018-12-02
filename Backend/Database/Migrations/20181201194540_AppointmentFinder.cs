using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HeyImIn.Database.Migrations
{
    public partial class AppointmentFinder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentFinders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentFinders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentFinders_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppointmentFinderId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlots_AppointmentFinders_AppointmentFinderId",
                        column: x => x.AppointmentFinderId,
                        principalTable: "AppointmentFinders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSlotParticipations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeSlotId = table.Column<int>(nullable: false),
                    ParticipantId = table.Column<int>(nullable: false),
                    AppointmentParticipationAnswer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlotParticipations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSlotParticipations_Users_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeSlotParticipations_TimeSlots_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentFinders_EventId",
                table: "AppointmentFinders",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotParticipations_ParticipantId",
                table: "TimeSlotParticipations",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotParticipations_TimeSlotId",
                table: "TimeSlotParticipations",
                column: "TimeSlotId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlotParticipations_Id_ParticipantId",
                table: "TimeSlotParticipations",
                columns: new[] { "Id", "ParticipantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_AppointmentFinderId",
                table: "TimeSlots",
                column: "AppointmentFinderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeSlotParticipations");

            migrationBuilder.DropTable(
                name: "TimeSlots");

            migrationBuilder.DropTable(
                name: "AppointmentFinders");
        }
    }
}
