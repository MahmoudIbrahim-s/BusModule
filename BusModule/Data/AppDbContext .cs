using BusModule.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<BusType> BusTypes { get; set; }
    public DbSet<BusCategory> BusCategories { get; set; }
    public DbSet<BusRoute> BusRoutes { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<BusAssignment> BusAssignments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

   
        // Entity Relationships
        

        modelBuilder.Entity<BusAssignment>()
            .HasOne(ba => ba.Student)
            .WithMany(s => s.BusAssignments)
            .HasForeignKey(ba => ba.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BusAssignment>()
            .HasOne(ba => ba.Bus)
            .WithMany(b => b.Assignments)
            .HasForeignKey(ba => ba.BusId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Bus>()
            .HasOne(b => b.BusType)
            .WithMany(bt => bt.Buses)
            .HasForeignKey(b => b.BusTypeId);

        modelBuilder.Entity<Bus>()
            .HasOne(b => b.BusCategory)
            .WithMany(bc => bc.Buses)
            .HasForeignKey(b => b.BusCategoryId);

        modelBuilder.Entity<Bus>()
            .HasOne(b => b.BusRoute)
            .WithMany(br => br.Buses)
            .HasForeignKey(b => b.BusRouteId);
        modelBuilder.Entity<Bus>()
            .HasOne(b => b.Driver)
            .WithMany(e => e.Buses)
            .HasForeignKey(b => b.DriverId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Bus>()
         .Property(b => b.Fees)
           .HasPrecision(10, 4);
        // User → Student
        modelBuilder.Entity<User>()
            .HasOne(u => u.Student)
            .WithOne(s => s.User)
            .HasForeignKey<User>(u => u.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        // User → Employee
        modelBuilder.Entity<User>()
            .HasOne(u => u.Employee)
            .WithOne(e => e.User)
            .HasForeignKey<User>(u => u.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Seed Data
        modelBuilder.Entity<BusType>().HasData(
            new BusType { Id = 1, Name = "Primary" },
            new BusType { Id = 2, Name = "Kindergarten" }
        );

        modelBuilder.Entity<BusCategory>().HasData(
            new BusCategory { Id = 1, Name = "One Way" },
            new BusCategory { Id = 2, Name = "Two Way" }
        );

        modelBuilder.Entity<BusRoute>().HasData(
            new BusRoute
            {
                Id = 1,
                RouteName = "Route A",
                StartPoint = "School",
                EndPoint = "Area 1",
                StartTime = new TimeSpan(7, 30, 0),
                EndTime = new TimeSpan(8, 30, 0)
            },
            new BusRoute
            {
                Id = 2,
                RouteName = "Route B",
                StartPoint = "School",
                EndPoint = "Area 2",
                StartTime = new TimeSpan(7, 45, 0),
                EndTime = new TimeSpan(8, 45, 0)
            }
        );

       
        modelBuilder.Entity<Bus>().HasData(
            new Bus
            {
                Id = 10,
                BusNumber = "BUS-101",
                DriverId = 10, 
                BusTypeId = 1,
                BusCategoryId = 2,
                BusRouteId = 1,
                Capacity = 30,
                Fees = 150.00m,
                IsCapacityRestricted = true
            }
        );
        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                FullName = "Ali Ahmed",
                Grade = "Grade 3"
            },
            new Student
            {
                Id = 2,
                FullName = "Salma Ibrahim",
                Grade = "Grade 4"
            }
        );
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 10,
                FullName = "John Doe",
                Role = "Driver"

            },
            new Employee
            {
                Id = 11,
                FullName = "Jane Smith",
                Role = "Admin"
            }
        );
        modelBuilder.Entity<User>().HasData(
    new User
    {
        Id = 1,
        Email = "ali@student.com",
        Password = "123456",
        Role = "Student",
        StudentId = 1
    },
    new User
    {
        Id = 2,
        Email = "salma@student.com",
        Password = "654321",
        Role = "Student",
        StudentId = 2
    },
    new User
    {
        Id = 3,
        Email = "john@driver.com",
        Password = "driver123",
        Role = "Driver",
        EmployeeId = 10
    },
    new User
    {
        Id = 4,
        Email = "jane@admin.com",
        Password = "admin123",
        Role = "Admin",
        EmployeeId = 11
    }
);

    }
}
