namespace BusModule.DTOs
{
    public class BusRouteDto
    {
        public int Id { get; set; }
        public string RouteName { get; set; } = string.Empty;
        public string StartPoint { get; set; } = string.Empty;
        public string EndPoint { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
