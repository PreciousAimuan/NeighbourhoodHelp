using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeighbourhoodHelp.Data.Migrations
{
    public partial class newUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Errands_ErrandId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ErrandId",
                table: "Payments");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Errands",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Errands",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
    }
}
