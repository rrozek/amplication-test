using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class ExtraSkillsExtensions
{
    public static ExtraSkill ToDto(this ExtraSkillDbModel model)
    {
        return new ExtraSkill
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            Id = model.Id,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ExtraSkillDbModel ToModel(
        this ExtraSkillUpdateInput updateDto,
        ExtraSkillWhereUniqueInput uniqueId
    )
    {
        var extraSkill = new ExtraSkillDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Name = updateDto.Name
        };

        if (updateDto.CreatedAt != null)
        {
            extraSkill.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            extraSkill.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return extraSkill;
    }
}
