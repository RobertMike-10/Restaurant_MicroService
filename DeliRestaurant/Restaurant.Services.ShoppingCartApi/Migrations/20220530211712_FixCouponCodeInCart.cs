using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Services.ShoppingCartApi.Migrations
{
    public partial class FixCouponCodeInCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CuoponCode",
                table: "CartHeaders",
                newName: "CouponCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CouponCode",
                table: "CartHeaders",
                newName: "CuoponCode");
        }
    }
}
