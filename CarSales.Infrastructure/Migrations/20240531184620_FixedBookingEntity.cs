using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedBookingEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Cars_CarId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Bookings",
                newName: "PriceId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CarId",
                table: "Bookings",
                newName: "IX_Bookings_PriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Prices_PriceId",
                table: "Bookings",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Prices_PriceId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "PriceId",
                table: "Bookings",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_PriceId",
                table: "Bookings",
                newName: "IX_Bookings_CarId");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Bookings",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bookings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Cars_CarId",
                table: "Bookings",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
