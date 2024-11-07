using MavJest.Database.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MavJest.Database.Context;

/// <summary>
/// EF DB Context Class to use with MavJest
/// </summary>
public class MavJestContext : DbContext
{
    /// <summary>
    /// Student DB Set
    /// </summary>
    public DbSet<Student> Student { get; set; }

    /// <summary>
    /// Activity Details DB Set
    /// </summary>
    public DbSet<ActivityDetails> ActivityDetails { get; set; }

    /// <summary>
    /// Academic History DB Set
    /// </summary>
    public DbSet<AcademicHistory> AcademicHistory { get; set; }

    /// <summary>
    /// Behaviour History DB Set
    /// </summary>
    public DbSet<BehaviourHistory> BehaviourHistory { get; set; }

    /// <summary>
    /// Activity History DB Set
    /// </summary>
    public DbSet<ActivityHistory> ActivityHistory { get; set; }

    /// <summary>
    /// EF On Model Creating Handler for Code First Approach
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Student entity
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id);  // Primary Key
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.SchoolGeneratedId).IsRequired().HasMaxLength(50);
            entity.Property(e => e.FatherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.MotherName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Class).IsRequired().HasMaxLength(20);
            entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(15);
            entity.Property(e => e.Image).HasMaxLength(100);
        });

        // Configure ActivityDetails entity
        modelBuilder.Entity<ActivityDetails>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.ActivityName).IsRequired().HasMaxLength(100);
        });

        // Configure AcademicHistory entity
        modelBuilder.Entity<AcademicHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Student)
                  .WithMany()
                  .HasForeignKey(e => e.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);  // When student is deleted, academic records are also deleted
        });

        // Configure BehaviourHistory entity
        modelBuilder.Entity<BehaviourHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Student)
                  .WithMany()
                  .HasForeignKey(e => e.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Self-referencing foreign key for seating with another student
            entity.HasOne(e => e.SeatedWithStudent)
                  .WithMany()
                  .HasForeignKey(e => e.SeatedWithStudentId)
                  .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion if seated student exists
        });

        // Configure ActivityHistory entity
        modelBuilder.Entity<ActivityHistory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Student)
                  .WithMany()
                  .HasForeignKey(e => e.StudentId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.ActivityDetails)
                  .WithMany()
                  .HasForeignKey(e => e.ActivityDetailsId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// EF On Configuring Handler for Code First Approach.
    /// This method will also seed initial data for working.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Ensure the 'database' directory exists
        var directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MavJestDatabase");
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Specify the SQLite database file in the 'database' folder
        var dbPath = Path.Combine(directory, "mavjest.db");

        if (!File.Exists(dbPath))
        {
            this.ExecuteSqlFile(dbPath);
        }

        // Specify the SQLite database file
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    private void ExecuteSqlFile(string dbPath)
    {
        foreach (string filePath in Directory.EnumerateFiles("../DB/SQL"))
        {
            var sqlStatements = File.ReadAllText(filePath); // Read SQL from the file

            using (var connection = new SqliteConnection($"Data Source={dbPath}"))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sqlStatements;
                    command.ExecuteNonQuery(); // Execute the SQL file
                }
            }
        }
    }
}
