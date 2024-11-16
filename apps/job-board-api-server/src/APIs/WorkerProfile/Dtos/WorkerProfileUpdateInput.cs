namespace JobBoardApi.APIs.Dtos;

public class WorkerProfileUpdateInput
{
    public int? Age { get; set; }

    public List<string>? Applications { get; set; }

    public string? Availability { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Gender { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public int? SalaryExpectation { get; set; }

    public int? SalaryMax { get; set; }

    public int? SalaryMin { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? User { get; set; }

    public bool? WillingnessToWorkAbroad { get; set; }
}
