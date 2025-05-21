namespace Core.Entities;

public class RegistredUser
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public UserProfile? Profile { get; set; }

}
