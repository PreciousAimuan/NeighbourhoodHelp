using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighbourhoodHelp.Data.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agents_AspNetUsers_AppUserId",
                table: "agents");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "agents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_agents_AspNetUsers_AppUserId",
                table: "agents",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agents_AspNetUsers_AppUserId",
                table: "agents");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "agents",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_agents_AspNetUsers_AppUserId",
                table: "agents",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
