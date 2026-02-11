using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;

namespace Module02.Lesson16.EfCoreSetupDemo
{
    // 1) Entity
    public class Student
    {
        public int Id { get; set; }        // Primary key by convention
        public string Name { get; set; }
        public int Age { get; set; }
    }

    // 2) DbContext
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        // Configure database provider/connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite file for simplicity in a classroom setting
            //optionsBuilder.UseSqlite("Data Source=school.db");
            // Force SQLite to use a single database file in the project root.
            // Prevents "no such table" errors caused by different working
            // directories between `dotnet run` and Visual Studio.
            var dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "school.db");
            dbPath = Path.GetFullPath(dbPath);

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        // Optional: basic constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }

    // 3) Program
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== EF Core Setup Demo (Solution) ===");

            using var context = new SchoolContext();

            // Ensure database and schema are created (for classroom demos)
            context.Database.EnsureCreated();

            // Seed if empty
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student { Name = "Alice", Age = 20 },
                    new Student { Name = "Bob", Age = 22 },
                    new Student { Name = "Charlie", Age = 19 }
                );
                context.SaveChanges();
                Console.WriteLine("Database seeded with sample students.");
            }

            // Query
            List<Student> students = context.Students
                                            .OrderBy(s => s.Id)
                                            .ToList();

            Console.WriteLine("\nAll Students in Database:");
            foreach (var s in students)
            {
                Console.WriteLine($"ID={s.Id}, Name={s.Name}, Age={s.Age}");
            }
        }
    }
}


