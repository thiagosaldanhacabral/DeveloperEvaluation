namespace DeveloperEvaluation.Common.Common;

public class ApiResponseWithData<T> : ApiResponse
{
    public bool Success { get; set; }
    public new T? Data { get; set; }
}
