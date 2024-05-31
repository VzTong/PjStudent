namespace PjStudent.Models;
using Microsoft.EntityFrameworkCore;

public class PjStudentDBContext : DbContext
{
    public DbSet<AppStudent> AppStudents { get; set; }

    public PjStudentDBContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // m -> viết tắt cho models
        // Table AppStudent
        modelBuilder.Entity<AppStudent>()
                    .Property(m => m.CodeID)
                    .HasMaxLength(6);

        modelBuilder.Entity<AppStudent>()
                    .Property(m => m.FullName)
                    .HasMaxLength(200);

        modelBuilder.Entity<AppStudent>()
                    .Property(m => m.HomeTown)
                    .HasMaxLength(200);

        modelBuilder.Entity<AppStudent>()
                    .Property(m => m.PhoneNumber)
                    .HasMaxLength(16);

        modelBuilder.Entity<AppStudent>()
                    .Property(m => m.Avatar)
                    .HasMaxLength(200);

    }
}

