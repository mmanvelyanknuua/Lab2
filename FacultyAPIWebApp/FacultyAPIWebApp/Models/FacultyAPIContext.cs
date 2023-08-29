using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FacultyAPIWebApp.Models
{
    public class FacultyAPIContext : DbContext
    {
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentSection> StudentSections { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        public FacultyAPIContext(DbContextOptions<FacultyAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            var pmConfig = mb.Entity<Section>();
            pmConfig.HasOne(n => n.Teacher).WithMany(n => n.Sections).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
