namespace CarSales.Application.Bookings
{
    public record BookingDTO
    {
        public Guid PriceId { get; set; }

        public DateTimeOffset BookingStartDate { get; set; }

        public DateTimeOffset BookingEndDate { get; set; }

        public decimal Price { get; set; }

        public string Username { get; set; } = string.Empty;
    }

}
