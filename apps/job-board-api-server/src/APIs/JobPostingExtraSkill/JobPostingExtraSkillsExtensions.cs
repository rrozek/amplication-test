using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class JobPostingExtraSkillsExtensions
{
    public static JobPostingExtraSkill ToDto(this JobPostingExtraSkillDbModel model)
    {
        return new JobPostingExtraSkill
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static JobPostingExtraSkillDbModel ToModel(
        this JobPostingExtraSkillUpdateInput updateDto,
        JobPostingExtraSkillWhereUniqueInput uniqueId
    )
    {
        var jobPostingExtraSkill = new JobPostingExtraSkillDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            jobPostingExtraSkill.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            jobPostingExtraSkill.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return jobPostingExtraSkill;
    }
}
