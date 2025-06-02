using BusModule.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<BusType> BusTypes { get; set; }
    public DbSet<BusCategory> BusCategories { get; set; }
    public DbSet<BusRoute> BusRoutes { get; set; }
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<BusAssignment> BusAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Student-BusAssignment
        modelBuilder.Entity<BusAssignment>()
            .HasOne(ba => ba.Student)
            .WithMany(s => s.BusAssignments)
            .HasForeignKey(ba => ba.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Bus-BusAssignment
        modelBuilder.Entity<BusAssignment>()
            .HasOne(ba => ba.Bus)
            .WithMany(b => b.Assignments)
            .HasForeignKey(ba => ba.BusId)
            .OnDelete(DeleteBehavior.Cascade);

        // BusType-Bus
        modelBuilder.Entity<Bus>()
            .HasOne(b => b.BusType)
            .WithMany(bt => bt.Buses)
            .HasForeignKey(b => b.BusTypeId);

        // BusCategory-Bus
        modelBuilder.Entity<Bus>()
            .HasOne(b => b.BusCategory)
            .WithMany(bc => bc.Buses)
            .HasForeignKey(b => b.BusCategoryId);

        // BusRoute-Bus
        modelBuilder.Entity<Bus>()
            .HasOne(b => b.BusRoute)
            .WithMany(br => br.Buses)
            .HasForeignKey(b => b.BusRouteId);
    }
}
