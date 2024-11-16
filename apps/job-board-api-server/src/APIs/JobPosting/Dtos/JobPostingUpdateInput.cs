namespace JobBoardApi.APIs.Dtos;

public class JobPostingUpdateInput
{
    public string? Agency { get; set; }

    public int? AnalyticsApplications { get; set; }

    public int? AnalyticsClicks { get; set; }

    public int? AnalyticsViews { get; set; }

    public List<string>? Applications { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? Location { get; set; }

    public int? SalaryMax { get; set; }

    public int? SalaryMin { get; set; }

    public string? Title { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
