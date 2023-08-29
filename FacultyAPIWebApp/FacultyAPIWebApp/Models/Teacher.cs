namespace FacultyAPIWebApp.Models
{
    public class Teacher
    {
        public Teacher() {
            Sections = new List<Section>();
        }

        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Section> Sections { get; set; }

    }
}
