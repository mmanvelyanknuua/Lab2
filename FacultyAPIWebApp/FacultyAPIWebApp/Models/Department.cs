namespace FacultyAPIWebApp.Models
{
    public class Department
    {

        public Department() {
            Teachers = new List<Teacher>();
            Courses = new List<Course>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}
