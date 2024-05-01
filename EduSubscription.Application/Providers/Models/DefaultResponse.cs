namespace EduSubscription.Application.Providers.Models;

public class DefaultResponse<TData> where TData : notnull
{
    public int Count { get; set; } = 0;
    public int StatusCode { get; set; } = 0;
    public string ErrorMessage { get; set; } = string.Empty;
    public List<TData> Data { get; set; } = default!;
}