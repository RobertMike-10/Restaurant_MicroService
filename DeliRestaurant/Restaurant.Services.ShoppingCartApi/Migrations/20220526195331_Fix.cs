using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Services.ShoppingCartApi.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "CartHeaders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "cuoponCode",
                table: "CartHeaders",
                newName: "CuoponCode");

            migrationBuilder.RenameColumn(
                name: "CardHeaderId",
                table: "CartHeaders",
                newName: "CartHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "CartHeaders",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "CuoponCode",
                table: "CartHeaders",
                newName: "cuoponCode");

            migrationBuilder.RenameColumn(
                name: "CartHeaderId",
                table: "CartHeaders",
                newName: "CardHeaderId");
        }
    }
}
