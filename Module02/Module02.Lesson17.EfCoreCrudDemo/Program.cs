using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

// EfCoreCrudDemo.cs
// EF Core demo: CRUD operations + one-to-many relationship (Course -> Students)
//
// Requires NuGet packages:
//   - Microsoft.EntityFrameworkCore
//   - Microsoft.EntityFrameworkCore.Sqlite
//
// Build & Run (CLI):
//   dotnet add package Microsoft.EntityFrameworkCore
//   dotnet add package Microsoft.EntityFrameworkCore.Sqlite
//   dotnet run
//
// For production apps prefer Migrations over EnsureCreated (notes at bottom)

namespace Module02.Lesson17.EfCoreCrudDemo
{
    // -----------------------------
    // Entities (One Course, many Students)
    // -----------------------------
    public class Course
    {
        public int Id { get; set; }                 // PK
        public string Code { get; set; } = "";      // e.g., "SDEV2301"
        public string Name { get; set; } = "";      // e.g., "Enterprise App Dev"
        public int Credits { get; set; } = 3;

        // Navigation: one-to-many
        public List<Student> Students { get; set; } = new();
    }

    public class Student
    {
        public int Id { get; set; }                 // PK
        public string Name { get; set; } = "";
        public int Age { get; set; }

        // FK + Navigation back to Course
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }

    // -----------------------------
    // DbContext
    // -----------------------------
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseSqlite("Data Source=school_crud_demo.db");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite file for simplicity in a classroom setting
            //optionsBuilder.UseSqlite("Data Source=school.db");
            // Force SQLite to use a single database file in the project root.
            // Prevents "no such table" errors caused by different working
            // directories between `dotnet run` and Visual Studio.
            var dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "school_crud_demo.db");
            dbPath = Path.GetFullPath(dbPath);

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(b =>
            {
                b.Property(c => c.Code).IsRequired().HasMaxLength(20);
                b.Property(c => c.Name).IsRequired().HasMaxLength(100);
                b.HasMany(c => c.Students)
                 .WithOne(s => s.Course!)
                 .HasForeignKey(s => s.CourseId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Student>(b =>
            {
                b.Property(s => s.Name).IsRequired().HasMaxLength(100);
            });
        }
    }

    // -----------------------------
    // Demo Program
    // -----------------------------
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== EF Core CRUD + Relationships Demo ===");

            using var db = new SchoolContext();

            // 0) Bootstrap schema (for demos). Prefer Migrations in real apps.
            db.Database.EnsureDeleted();      // comment out after first run if you want to keep data
            db.Database.EnsureCreated();

            // 1) CREATE -------------------------------------------------------
            var course = new Course { Code = "SDEV2301", Name = "Enterprise App Dev", Credits = 3 };
            db.Courses.Add(course);

            db.Students.AddRange(
                new Student { Name = "Alice", Age = 20, Course = course },
                new Student { Name = "Bob", Age = 22, Course = course },
                new Student { Name = "Cara", Age = 19, Course = course }
            );

            db.SaveChanges();
            Console.WriteLine("Created course + 3 students.");

            // 2) READ (with relationship) ------------------------------------
            var loadedCourse = db.Courses
                .Include(c => c.Students)
                .Single(c => c.Code == "SDEV2301");

            Console.WriteLine($"\nREAD: {loadedCourse.Code} - {loadedCourse.Name} ({loadedCourse.Credits} credits)");
            foreach (var s in loadedCourse.Students)
                Console.WriteLine($" - Student #{s.Id}: {s.Name} (Age {s.Age})");

            // 3) UPDATE (entity + child) -------------------------------------
            loadedCourse.Credits = 4; // update parent
            var bob = loadedCourse.Students.Single(s => s.Name == "Bob");
            bob.Age = 23;             // update child
            db.SaveChanges();
            Console.WriteLine("\nUPDATE: Course credits -> 4; Bob's age -> 23");

            // Show updated state
            var check = db.Courses.Include(c => c.Students).Single(c => c.Id == loadedCourse.Id);
            //Console.WriteLine($"Confirm: {check.Code} now {check.Credits} credits; Bob age = {check.Students.Single(s => s.Name == \"Bob\").Age}");
            Console.WriteLine($"Confirm: {check.Code} now {check.Credits} credits;");
            // 4) DELETE (child or parent) ------------------------------------
            // Delete one student
            var cara = check.Students.Single(s => s.Name == "Cara");
            db.Students.Remove(cara);
            db.SaveChanges();
            Console.WriteLine("\nDELETE: Removed Cara.");

            // Delete the course (cascade deletes remaining students)
            db.Courses.Remove(check);
            db.SaveChanges();
            Console.WriteLine("DELETE: Removed course (cascade deleted remaining students).");

            // 5) Verify empty -------------------------------------------------
            Console.WriteLine($"\nCounts -> Courses: {db.Courses.Count()}, Students: {db.Students.Count()}");
            Console.WriteLine("\nDemo complete.");
        }
    }
}

/*
	NOTES: Migrations vs EnsureCreated
	----------------------------------
	- For quick demos, EnsureCreated/EnsureDeleted is convenient (no migration history).
	- For real projects, use Migrations to evolve schema with version history:

		dotnet add package Microsoft.EntityFrameworkCore.Tools
		dotnet ef migrations add InitialCreate
		dotnet ef database update

	- After switching to migrations, remove EnsureDeleted/EnsureCreated and call:
		db.Database.Migrate();
	*/