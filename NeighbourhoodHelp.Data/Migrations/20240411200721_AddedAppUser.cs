using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighbourhoodHelp.Data.Migrations
{
    public partial class AddedAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentAppUser_Agent_AgentsId",
                table: "AgentAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Errands_Agent_AgentId",
                table: "Errands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agent",
                table: "Agent");

            migrationBuilder.RenameTable(
                name: "Agent",
                newName: "agents");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgentId",
                table: "Errands",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_agents",
                table: "agents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentAppUser_agents_AgentsId",
                table: "AgentAppUser",
                column: "AgentsId",
                principalTable: "agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Errands_agents_AgentId",
                table: "Errands",
                column: "AgentId",
                principalTable: "agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentAppUser_agents_AgentsId",
                table: "AgentAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Errands_agents_AgentId",
                table: "Errands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agents",
                table: "agents");

            migrationBuilder.RenameTable(
                name: "agents",
                newName: "Agent");

            migrationBuilder.AlterColumn<Guid>(
                name: "AgentId",
                table: "Errands",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agent",
                table: "Agent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentAppUser_Agent_AgentsId",
                table: "AgentAppUser",
                column: "AgentsId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Errands_Agent_AgentId",
                table: "Errands",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id");
        }
    }
}
