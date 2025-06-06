namespace BusModule.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = "Student"; //  "Student";  or "Admin"
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public int? StudentId { get; set; }
        public Student? Student { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }

}

