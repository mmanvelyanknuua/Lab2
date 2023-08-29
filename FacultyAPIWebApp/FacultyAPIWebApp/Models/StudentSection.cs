namespace FacultyAPIWebApp.Models
{
    public class StudentSection
    {
        public StudentSection() { 
        
        }

        public int Id { get; set; }
        public int StudentId { get; set;}
        public int SectionId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Section Section { get; set; }
    }
}
