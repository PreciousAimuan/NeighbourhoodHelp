using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighbourhoodHelp.Data.Migrations
{
    public partial class vv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Errands_AspNetUsers_AppUserId",
                table: "Errands");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Errands",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Errands_AspNetUsers_AppUserId",
                table: "Errands",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Errands_AspNetUsers_AppUserId",
                table: "Errands");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Errands",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Errands_AspNetUsers_AppUserId",
                table: "Errands",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
