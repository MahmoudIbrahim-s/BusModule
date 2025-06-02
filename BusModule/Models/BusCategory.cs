namespace BusModule.Models
{
    public class BusCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //  One Way, Two Way

        public ICollection<Bus>? Buses { get; set; }
    }
}
