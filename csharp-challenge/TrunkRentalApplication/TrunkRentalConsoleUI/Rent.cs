namespace TrunkRentalConsoleUI
{
    class Rent
    {
        public decimal AdditionalCostPerHours { get; set; }
        public (decimal cost, int minutes) FirstCostPerNumberMinutes { get; set; }
    }
}
