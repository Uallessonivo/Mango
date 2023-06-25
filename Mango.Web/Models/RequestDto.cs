using Mango.Web.Utility;

namespace Mango.Web.Models;

public class RequestDto
{
    public Sd.ApiType ApiType { get; set; } = Sd.ApiType.GET;
    public string? Url { get; set; }
    public object? Data { get; set; }
    public string? AccessToken { get; set; }
}