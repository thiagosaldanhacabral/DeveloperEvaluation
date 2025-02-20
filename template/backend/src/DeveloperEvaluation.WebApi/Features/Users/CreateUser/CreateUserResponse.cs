using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// API response model for CreateUser operation
/// </summary>
public record CreateUserResponse
{
    /// <summary>
    /// The unique identifier of the created user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's full name
    /// </summary>
    //public Name Name { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    ////public Name? Name { get; set; }

    public Address? Address { get; set; }

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// The user's role in the system
    /// </summary>
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// The current status of the user
    /// </summary>
    public string Status { get; set; } = string.Empty;
}

////public class Name
////{
////    public string FirstName { get; set; } = string.Empty;

////    public string LastName { get; set; } = string.Empty;
////}
