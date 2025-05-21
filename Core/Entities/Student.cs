namespace Core.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }       
    public int Age { get; set; }
    public int? TutorId { get; set; } // Forean key optional
    public Tutor? Tutor { get; set; }
    public ICollection<SchoolClass> SchoolClasses { get; set; }

}
