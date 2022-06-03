using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceSiteDemo.Data.Migrations
{
    public partial class changeinorderdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Order_Details_order_id",
                table: "Order_Details",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Details_Order_order_id",
                table: "Order_Details",
                column: "order_id",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Details_Order_order_id",
                table: "Order_Details");

            migrationBuilder.DropIndex(
                name: "IX_Order_Details_order_id",
                table: "Order_Details");
        }
    }
}
