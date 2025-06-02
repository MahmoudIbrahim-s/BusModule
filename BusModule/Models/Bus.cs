namespace BusModule.Models
{
    public class Bus
    {
        public int Id { get; set; }
        public string BusNumber { get; set; } = string.Empty;
        public int DriverId { get; set; } 
        public int BusTypeId { get; set; }
        public int BusCategoryId { get; set; }
        public int BusRouteId { get; set; }

        public int Capacity { get; set; }
        public decimal Fees { get; set; }
        public bool IsCapacityRestricted { get; set; }

        public BusType? BusType { get; set; }
        public BusCategory? BusCategory { get; set; }
        public BusRoute? BusRoute { get; set; }

        public ICollection<BusAssignment>? Assignments { get; set; }
    }
}
