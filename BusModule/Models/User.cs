namespace BusModule.Models
{
    public class User
    {
        public int Id { get; set; }

        public string EncryptedEmail { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;

        public string Role { get; set; } = "Student"; //  "Student";  or "Admin"

        public int? UserId { get; set; }
    }
    
    }

