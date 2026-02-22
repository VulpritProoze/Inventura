namespace Inventura.Application.Common.Interfaces;

public interface IUser
{
    string? Id { get; set; }
    List<string>? Roles { get; set; }
}
