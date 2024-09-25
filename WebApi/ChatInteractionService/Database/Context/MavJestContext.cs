using ChatInteractionService.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatInteractionService.Database.Context
{
    public class MavJestContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ActivityHistory> ActivityHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Ensure the 'database' directory exists
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Database");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Specify the SQLite database file in the 'database' folder
            var dbPath = Path.Combine(directory, "mavjest.db");

            // Specify the SQLite database file
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, keys, and constraints if needed
            modelBuilder.Entity<ActivityHistory>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(a => a.StudentId);
        }
    }
}
