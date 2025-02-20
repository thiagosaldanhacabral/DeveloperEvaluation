using DeveloperEvaluation.Application.Users.DeleteUser;
using DeveloperEvaluation.Domain.Entities;
using AutoMapper;
using Microsoft.OpenApi.Extensions;

namespace DeveloperEvaluation.WebApi.Features.Users.DeleteUser;

/// <summary>
/// Profile for mapping DeleteUser feature requests to commands
/// </summary>
public class DeleteUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteUser feature
    /// </summary>
    public DeleteUserProfile()
    {
        CreateMap<Guid, Application.Users.DeleteUser.DeleteUserCommand>()
            .ConstructUsing(id => new Application.Users.DeleteUser.DeleteUserCommand(id));

        CreateMap<User, DeleteUserResult>()
             .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.GetDisplayName()))
           .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.GetDisplayName()));

        CreateMap<DeleteUserResult, DeleteUserResponse>()
        .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}
