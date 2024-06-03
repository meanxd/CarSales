using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnforceUniqueBookingPriceIdWithIsDeletedFalse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_PriceId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PriceId",
                table: "Bookings",
                column: "PriceId",
                unique: true,
                filter: "NOT (\"IsDeleted\")");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_PriceId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PriceId",
                table: "Bookings",
                column: "PriceId");
        }
    }
}
