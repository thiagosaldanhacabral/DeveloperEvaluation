using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Application.Users.ListUser;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class ListUserResult
{
    public List<User>? Users { get; set; }
}
