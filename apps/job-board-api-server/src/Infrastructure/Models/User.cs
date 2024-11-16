using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobBoardApi.Core.Enums;

namespace JobBoardApi.Infrastructure.Models;

[Table("Users")]
public class UserDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    public string? Email { get; set; }

    [StringLength(256)]
    public string? FirstName { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(256)]
    public string? LastName { get; set; }

    [Required()]
    public string Password { get; set; }

    public RoleEnum? Role { get; set; }

    [Required()]
    public string Roles { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    public string Username { get; set; }

    public List<WorkerProfileDbModel>? WorkerProfiles { get; set; } =
        new List<WorkerProfileDbModel>();
}
