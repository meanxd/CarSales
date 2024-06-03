namespace CarSales.Application.Prices
{
    public record PriceDTO
    {
        public Guid CarId { get; set; }

        public Guid Id { get; set; }

        public decimal Price { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }


        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;
    }

}
