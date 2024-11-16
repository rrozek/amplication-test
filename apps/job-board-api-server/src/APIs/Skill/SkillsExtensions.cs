using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class SkillsExtensions
{
    public static Skill ToDto(this SkillDbModel model)
    {
        return new Skill
        {
            CreatedAt = model.CreatedAt,
            Grading = model.Grading,
            Id = model.Id,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static SkillDbModel ToModel(
        this SkillUpdateInput updateDto,
        SkillWhereUniqueInput uniqueId
    )
    {
        var skill = new SkillDbModel
        {
            Id = uniqueId.Id,
            Grading = updateDto.Grading,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            skill.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            skill.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return skill;
    }
}
