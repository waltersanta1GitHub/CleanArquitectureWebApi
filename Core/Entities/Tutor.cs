namespace Core.Entities;

public class Tutor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}
