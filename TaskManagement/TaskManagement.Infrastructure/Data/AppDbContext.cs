using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.HasOne(t => t.AssignedUserNav)
                    .WithMany(u => u.Tasks)
                    .HasForeignKey(t => t.AssignedUserId)
                    .HasConstraintName("FK_TaskItem_User_AssignedUserId")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(t => t.AssignedUserId).HasColumnName("AssignedUserId");
            });

            // Apply configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Seed data
            DataSeeder.Seed(modelBuilder);
        }
    }
}