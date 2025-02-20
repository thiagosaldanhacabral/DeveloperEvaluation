using DeveloperEvaluation.Common.Validation;

namespace DeveloperEvaluation.Common.Common;

public class ApiResponseError
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public object? Data { get; set; } 
    public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];
}
