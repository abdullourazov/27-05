using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Addres> Addres { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentGroup>().HasKey(sg => new { sg.StudentId, sg.Groupid });


        modelBuilder.Entity<Course>()
        .Property(c => c.Description)
        .IsRequired(false)
        .HasMaxLength(200);

        modelBuilder.Entity<Course>()
        .HasMany(c => c.Groups)
        .WithOne(g => g.Course)
        .HasForeignKey(g => g.CourseId);

        modelBuilder.Entity<Group>()
        .HasMany(g => g.StudentGroups)
        .WithOne(sg => sg.Group)
        .HasForeignKey(sg => sg.Groupid);

        modelBuilder.Entity<Student>()
        .HasMany(s => s.StudentGroups)
        .WithOne(sg => sg.Student);
    }

}
