namespace Core.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }     
    public string Speciality { get; set; }
    public ICollection<SchoolClass> SchoolClasses { get; set; }
   
}
