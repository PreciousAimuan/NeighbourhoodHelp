using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighbourhoodHelp.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserCounterOffers",
                table: "Errands",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ErrandId",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ErrandId",
                table: "Payments",
                column: "ErrandId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Errands_ErrandId",
                table: "Payments",
                column: "ErrandId",
                principalTable: "Errands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Errands_ErrandId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ErrandId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserCounterOffers",
                table: "Errands");

            migrationBuilder.DropColumn(
                name: "ErrandId",
                table: "AspNetUsers");
        }
    }
}
