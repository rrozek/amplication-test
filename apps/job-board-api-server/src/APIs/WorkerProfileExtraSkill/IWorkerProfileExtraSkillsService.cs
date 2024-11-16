using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IWorkerProfileExtraSkillsService
{
    /// <summary>
    /// Create one WorkerProfileExtraSkill
    /// </summary>
    public Task<WorkerProfileExtraSkill> CreateWorkerProfileExtraSkill(
        WorkerProfileExtraSkillCreateInput workerprofileextraskill
    );

    /// <summary>
    /// Delete one WorkerProfileExtraSkill
    /// </summary>
    public Task DeleteWorkerProfileExtraSkill(WorkerProfileExtraSkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many WorkerProfileExtraSkills
    /// </summary>
    public Task<List<WorkerProfileExtraSkill>> WorkerProfileExtraSkills(
        WorkerProfileExtraSkillFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about WorkerProfileExtraSkill records
    /// </summary>
    public Task<MetadataDto> WorkerProfileExtraSkillsMeta(
        WorkerProfileExtraSkillFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one WorkerProfileExtraSkill
    /// </summary>
    public Task<WorkerProfileExtraSkill> WorkerProfileExtraSkill(
        WorkerProfileExtraSkillWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one WorkerProfileExtraSkill
    /// </summary>
    public Task UpdateWorkerProfileExtraSkill(
        WorkerProfileExtraSkillWhereUniqueInput uniqueId,
        WorkerProfileExtraSkillUpdateInput updateDto
    );
}
