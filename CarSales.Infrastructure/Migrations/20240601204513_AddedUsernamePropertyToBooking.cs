using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSales.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUsernamePropertyToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Bookings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Bookings");
        }
    }
}
