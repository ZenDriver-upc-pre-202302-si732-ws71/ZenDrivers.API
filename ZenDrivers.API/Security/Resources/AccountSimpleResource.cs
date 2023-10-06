namespace ZenDrivers.API.Security.Resources;

public class AccountSimpleResource
{
    public int Id { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string? ImageUrl { get; set; }
}