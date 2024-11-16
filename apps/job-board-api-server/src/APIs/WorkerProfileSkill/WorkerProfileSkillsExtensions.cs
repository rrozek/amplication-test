using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class WorkerProfileSkillsExtensions
{
    public static WorkerProfileSkill ToDto(this WorkerProfileSkillDbModel model)
    {
        return new WorkerProfileSkill
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static WorkerProfileSkillDbModel ToModel(
        this WorkerProfileSkillUpdateInput updateDto,
        WorkerProfileSkillWhereUniqueInput uniqueId
    )
    {
        var workerProfileSkill = new WorkerProfileSkillDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            workerProfileSkill.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            workerProfileSkill.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return workerProfileSkill;
    }
}
