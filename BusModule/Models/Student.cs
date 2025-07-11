﻿namespace BusModule.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public User? User { get; set; } 

        public ICollection<BusAssignment>? BusAssignments { get; set; }
    }
}
