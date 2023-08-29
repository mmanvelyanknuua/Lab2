namespace FacultyAPIWebApp.Models
{
    public class Section
    {
        public Section() {
            StudentSections = new List<StudentSection>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public virtual Course Course { get; set;}
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<StudentSection> StudentSections { get; set; }
    }
}
