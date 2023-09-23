namespace ZenDrivers.API.Security.Resources;

public class AccountDriverResource
{
    public int Id { get; set; }
    public string Address { get; set; } = null!;
    
    public DateTime Birth { get; set; }
}