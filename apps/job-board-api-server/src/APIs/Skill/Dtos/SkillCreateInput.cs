namespace JobBoardApi.APIs.Dtos;

public class SkillCreateInput
{
    public DateTime CreatedAt { get; set; }

    public int? Grading { get; set; }

    public string? Id { get; set; }

    public string? Name { get; set; }

    public DateTime UpdatedAt { get; set; }
}
