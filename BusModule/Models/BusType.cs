namespace BusModule.Models
{
    public class BusType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 

        public ICollection<Bus>? Buses { get; set; }
    }
}
