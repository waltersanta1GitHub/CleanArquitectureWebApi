namespace Core.Entities;

public class SchoolClass
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
   
    public int Period { get; set; }
    public DateTime Time { get; set; }

   
}
