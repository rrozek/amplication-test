using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class WorkerProfileExtraSkillsExtensions
{
    public static WorkerProfileExtraSkill ToDto(this WorkerProfileExtraSkillDbModel model)
    {
        return new WorkerProfileExtraSkill
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static WorkerProfileExtraSkillDbModel ToModel(
        this WorkerProfileExtraSkillUpdateInput updateDto,
        WorkerProfileExtraSkillWhereUniqueInput uniqueId
    )
    {
        var workerProfileExtraSkill = new WorkerProfileExtraSkillDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            workerProfileExtraSkill.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            workerProfileExtraSkill.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return workerProfileExtraSkill;
    }
}
