using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighbourhoodHelp.Data.Migrations
{
    public partial class ModifiedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Errands_AspNetUsers_AppUserId1",
                table: "Errands");

            migrationBuilder.DropIndex(
                name: "IX_Errands_AppUserId1",
                table: "Errands");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Errands");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Errands",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<int>(
                name: "AgentCounterOffers",
                table: "Errands",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Errands",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Errands",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Errands_AppUserId",
                table: "Errands",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Errands_AspNetUsers_AppUserId",
                table: "Errands",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Errands_AspNetUsers_AppUserId",
                table: "Errands");

            migrationBuilder.DropIndex(
                name: "IX_Errands_AppUserId",
                table: "Errands");

            migrationBuilder.DropColumn(
                name: "AgentCounterOffers",
                table: "Errands");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Errands");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Errands");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Errands",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Errands",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Errands_AppUserId1",
                table: "Errands",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Errands_AspNetUsers_AppUserId1",
                table: "Errands",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
