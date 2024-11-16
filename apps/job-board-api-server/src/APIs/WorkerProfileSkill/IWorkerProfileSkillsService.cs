using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IWorkerProfileSkillsService
{
    /// <summary>
    /// Create one WorkerProfileSkill
    /// </summary>
    public Task<WorkerProfileSkill> CreateWorkerProfileSkill(
        WorkerProfileSkillCreateInput workerprofileskill
    );

    /// <summary>
    /// Delete one WorkerProfileSkill
    /// </summary>
    public Task DeleteWorkerProfileSkill(WorkerProfileSkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WorkerProfileSkills
    /// </summary>
    public Task<List<WorkerProfileSkill>> WorkerProfileSkills(
        WorkerProfileSkillFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about WorkerProfileSkill records
    /// </summary>
    public Task<MetadataDto> WorkerProfileSkillsMeta(WorkerProfileSkillFindManyArgs findManyArgs);

    /// <summary>
    /// Get one WorkerProfileSkill
    /// </summary>
    public Task<WorkerProfileSkill> WorkerProfileSkill(WorkerProfileSkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one WorkerProfileSkill
    /// </summary>
    public Task UpdateWorkerProfileSkill(
        WorkerProfileSkillWhereUniqueInput uniqueId,
        WorkerProfileSkillUpdateInput updateDto
    );
}
