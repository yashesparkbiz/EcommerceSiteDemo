namespace EcommerceSiteDemo.Shared;

public class BaseResponseOut
{
    public const string message = "message"; /** To match the name of the 'message' param in constructor. Used by AutoMappers's ForCtorParam method */

    public BaseResponseOut() { }

    public BaseResponseOut(string message, List<string>? errors = null)
    {
        Message = message;
        Errors = errors ?? new();
    }

    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
}
