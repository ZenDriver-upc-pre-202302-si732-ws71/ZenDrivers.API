namespace ZenDrivers.API.Shared.Domain.Services.Communication;

public class ErrorResponse
{
    public string Message { get; }

    public ErrorResponse(string message)
    {
        this.Message = message;
    }
        
    public static ErrorResponse Of(string message) => new(message);
}