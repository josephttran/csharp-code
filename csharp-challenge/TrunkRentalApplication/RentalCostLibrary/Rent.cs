namespace RentalCostLibrary
{
    public class Rent
    {
        public decimal AdditionalCostPerHours { get; set; }
        public (decimal cost, int minutes) FirstCostPerNumberMinutes { get; set; }
        public int  MinutesConsideredAnHour { get; set; }
        public decimal CostPerWeekday { get; set; } = 400;
        public decimal CostPerWeekend { get; set; } = 200;
    }
}
