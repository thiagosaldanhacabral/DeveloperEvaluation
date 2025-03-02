using AutoMapper;
using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Application.Users.GetUser;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetUserProfile()
    {

        CreateMap<GetUserCommand, User>();
        CreateMap<User, GetUserResult>();
    }
}
