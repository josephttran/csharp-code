namespace RentalCostLibrary
{
    public class Rent
    {
        public decimal AdditionalCostPerHours { get; set; }
        public (decimal cost, int minutes) FirstCostPerNumberMinutes { get; set; }
        public int  MinutesConsideredAnHour { get; set; }
    }
}
