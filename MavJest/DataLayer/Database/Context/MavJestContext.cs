using ChatInteractionService.Database.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ChatInteractionService.Database.Context
{

    public class MavJestContext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<ActivityDetails> ActivityDetails { get; set; }
        public DbSet<AcademicHistory> AcademicHistory { get; set; }
        public DbSet<BehaviourHistory> BehaviourHistory { get; set; }
        public DbSet<ActivityHistory> ActivityHistory { get; set; }

        //// Constructor that passes options to the base DbContext class
        //public MavJestContext(DbContextOptions<MavJestContext> options) : base(options) { }

        // Configure the entity relationships and table mappings
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

        // Example: Configure connection string or other settings
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

            if(!File.Exists(dbPath))
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

}
