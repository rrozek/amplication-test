using JobBoardApi.Core.Enums;

namespace JobBoardApi.APIs.Dtos;

public class UserCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Id { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    public string Roles { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Username { get; set; }

    public List<WorkerProfile>? WorkerProfiles { get; set; }
}
