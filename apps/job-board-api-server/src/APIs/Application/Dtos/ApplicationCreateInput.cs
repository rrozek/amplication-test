namespace JobBoardApi.APIs.Dtos;

public class ApplicationCreateInput
{
    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public JobPosting? JobPosting { get; set; }

    public string? Status { get; set; }

    public DateTime UpdatedAt { get; set; }

    public WorkerProfile? WorkerProfile { get; set; }
}
