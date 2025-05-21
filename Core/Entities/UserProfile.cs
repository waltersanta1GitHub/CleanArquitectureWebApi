namespace Core.Entities;

public class UserProfile
{
    public int Id { get; set; }
    public string NickName { get; set; } = null!;
    public string AvatarUrl { get; set; } = null!;
    public RegistredUser RegistredUser { get; set; } = null!;
}
