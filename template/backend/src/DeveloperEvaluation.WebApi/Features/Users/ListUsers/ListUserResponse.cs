using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.WebApi.Features.Users.ListUsers;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public record ListUserResponse
{
    public List<User>? Data { get; set; }  // Lista de usu�rios
    public int TotalItems { get; set; }  // Total de itens no banco
    public int CurrentPage { get; set; }  // P�gina atual
    public int TotalPages { get; set; }  // Total de p�ginas

}
