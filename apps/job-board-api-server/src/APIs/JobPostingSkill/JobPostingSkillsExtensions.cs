using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class JobPostingSkillsExtensions
{
    public static JobPostingSkill ToDto(this JobPostingSkillDbModel model)
    {
        return new JobPostingSkill
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static JobPostingSkillDbModel ToModel(
        this JobPostingSkillUpdateInput updateDto,
        JobPostingSkillWhereUniqueInput uniqueId
    )
    {
        var jobPostingSkill = new JobPostingSkillDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            jobPostingSkill.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            jobPostingSkill.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return jobPostingSkill;
    }
}
