namespace JobBoardApi.APIs.Dtos;

public class ApplicationWhereInput
{
    public DateTime? CreatedAt { get; set; }

    public string? Id { get; set; }

    public string? JobPosting { get; set; }

    public string? Status { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? WorkerProfile { get; set; }
}
