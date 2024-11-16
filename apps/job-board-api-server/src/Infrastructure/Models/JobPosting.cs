using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoardApi.Infrastructure.Models;

[Table("JobPostings")]
public class JobPostingDbModel
{
    [StringLength(1000)]
    public string? Agency { get; set; }

    [Range(-999999999, 999999999)]
    public int? AnalyticsApplications { get; set; }

    [Range(-999999999, 999999999)]
    public int? AnalyticsClicks { get; set; }

    [Range(-999999999, 999999999)]
    public int? AnalyticsViews { get; set; }

    public List<ApplicationDbModel>? Applications { get; set; } = new List<ApplicationDbModel>();

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [StringLength(1000)]
    public string? Location { get; set; }

    [Range(-999999999, 999999999)]
    public int? SalaryMax { get; set; }

    [Range(-999999999, 999999999)]
    public int? SalaryMin { get; set; }

    [StringLength(1000)]
    public string? Title { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
