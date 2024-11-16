using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoardApi.Infrastructure.Models;

[Table("WorkerProfiles")]
public class WorkerProfileDbModel
{
    [Range(-999999999, 999999999)]
    public int? Age { get; set; }

    public List<ApplicationDbModel>? Applications { get; set; } = new List<ApplicationDbModel>();

    [StringLength(1000)]
    public string? Availability { get; set; }

    public string? ContactEmail { get; set; }

    [StringLength(1000)]
    public string? ContactPhone { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [StringLength(1000)]
    public string? Gender { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Range(-999999999, 999999999)]
    public int? SalaryExpectation { get; set; }

    [Range(-999999999, 999999999)]
    public int? SalaryMax { get; set; }

    [Range(-999999999, 999999999)]
    public int? SalaryMin { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    public bool? WillingnessToWorkAbroad { get; set; }
}
