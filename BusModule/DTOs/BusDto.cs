namespace BusModule.DTOs
{
    public class BusDto
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
    }
}
