using Microsoft.EntityFrameworkCore;
using ToDoPlanning.Data.Entities;


namespace ToDoPlanning.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TaskItem> TaskItems { get; set; }
    
    public DbSet<Developer> Developers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Developer>().HasData(
            new Developer { Id = 1, Name = "Dev1", Capacity = 1 },
            new Developer { Id = 2, Name = "Dev2", Capacity = 2 },
            new Developer { Id = 3, Name = "Dev3", Capacity = 3 },
            new Developer { Id = 4, Name = "Dev4", Capacity = 4 },
            new Developer { Id = 5, Name = "Dev5", Capacity = 5 }

        );
    }
}