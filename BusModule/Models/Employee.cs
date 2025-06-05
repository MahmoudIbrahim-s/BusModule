using BusModule.Models;

public class Employee
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = "Employee"; // Default role -> can be driver or admin
    public User? User { get; set; }

    public ICollection<Bus>? Buses { get; set; } 
}
