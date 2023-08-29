namespace FacultyAPIWebApp.Models
{
    public class Course
    {
        public Course() {
            Sections = new List<Section>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public virtual int DepartmentId { get; set; }
        public string Description { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
