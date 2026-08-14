using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityLMSAPI.Domain.Entities;

namespace UniversityLMSAPI.Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Faculty> Faculties => Set<Faculty>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Group> Groups => Set<Group>();

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();

    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Semester> Semesters => Set<Semester>();
    public DbSet<GroupSubject> GroupSubjects => Set<GroupSubject>();

    public DbSet<Classroom> Classrooms => Set<Classroom>();
    public DbSet<Timetable> Timetables => Set<Timetable>();

    public DbSet<CourseMaterial> CourseMaterials => Set<CourseMaterial>();
    public DbSet<Assignment> Assignments => Set<Assignment>();
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Attendance> Attendances => Set<Attendance>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
