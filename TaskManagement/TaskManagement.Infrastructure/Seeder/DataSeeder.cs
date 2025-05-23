using TaskManagement.Core.Entities;
using TaskManagement.Core.Dtos.Task;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // Seed users and tasks using HasData (design-time seeding)
        SeedUsers(modelBuilder);
        SeedTasks(modelBuilder);
    }

    private static void SeedUsers(ModelBuilder modelBuilder)
    {
        var users = new List<object> // Using object to avoid navigation issues
        {
            new
            {
                Id = 1L,
                UserName = "admin",
                Email = "admin@example.com",
                Password = "Admin@123",
                FirstName = "System",
                LastName = "Admin",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                DeletedAt = (DateTime?)null
            },
            new
            {
                Id = 2L,
                UserName = "johndoe",
                Email = "john.doe@example.com",
                Password = "John@123",
                FirstName = "John",
                LastName = "Doe",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                DeletedAt = (DateTime?)null
            }
        };

        modelBuilder.Entity<User>().HasData(users);
    }

    private static void SeedTasks(ModelBuilder modelBuilder)
    {
        var tasks = new List<object>
        {
            new
            {
                Id = 1L,
                Title = "Initialize project",
                Description = "Set up the initial project structure",
                AssignedUserId = 1L,
                StartDate = DateTime.UtcNow.AddDays(-2),
                EndDate = DateTime.UtcNow.AddDays(3),
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                DeletedAt = (DateTime?)null
            },
            new
            {
                Id = 2L,
                Title = "Database design",
                Description = "Design the database schema",
                AssignedUserId = 2L,
                StartDate = DateTime.UtcNow.AddDays(-1),
                EndDate = DateTime.UtcNow.AddDays(5),
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false,
                DeletedAt = (DateTime?)null
            }
        };

        modelBuilder.Entity<TaskItem>().HasData(tasks);
    }
}