using AutoMapper;
using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Application.Users.DeleteUser;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class DeleteUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public DeleteUserProfile()
    {

        CreateMap<DeleteUserCommand, User>();
        CreateMap<User, DeleteUserCommand>();
    }
}
