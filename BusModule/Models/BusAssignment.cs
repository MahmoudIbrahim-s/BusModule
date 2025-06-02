namespace BusModule.Models
{
    public class BusAssignment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int BusId { get; set; }

        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        public Student? Student { get; set; }
        public Bus? Bus { get; set; }
    }
}
