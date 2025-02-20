using DeveloperEvaluation.Domain.Enums;

namespace DeveloperEvaluation.WebApi.Features.Users.UpdateUser;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class UpdateUserRequest
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password. Must meet security requirements.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;


    public string City { get; set; } = string.Empty;


    public string Street { get; set; } = string.Empty;


    public int Number { get; set; }


    public string ZipCode { get; set; } = string.Empty;


    public string Latitude { get; set; } = string.Empty;


    public string Longitude { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the phone number in format (XX) XXXXX-XXXX.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address. Must be a valid email format.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the initial status of the user account.
    /// </summary>
    public UserStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the role assigned to the user.
    /// </summary>
    public UserRole Role { get; set; }
}
