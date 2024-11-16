using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoardApi.Infrastructure.Models;

[Table("Applications")]
public class ApplicationDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public string? JobPostingId { get; set; }

    [ForeignKey(nameof(JobPostingId))]
    public JobPostingDbModel? JobPosting { get; set; } = null;

    [StringLength(1000)]
    public string? Status { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? WorkerProfileId { get; set; }

    [ForeignKey(nameof(WorkerProfileId))]
    public WorkerProfileDbModel? WorkerProfile { get; set; } = null;
}
