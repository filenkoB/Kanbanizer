using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.DBEngine.Migrations
{
    public partial class InitialTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Participant_ParticipantId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_ParticipantId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Task");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantId",
                table: "Task",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_ParticipantId",
                table: "Task",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Participant_ParticipantId",
                table: "Task",
                column: "ParticipantId",
                principalTable: "Participant",
                principalColumn: "Id");
        }
    }
}
