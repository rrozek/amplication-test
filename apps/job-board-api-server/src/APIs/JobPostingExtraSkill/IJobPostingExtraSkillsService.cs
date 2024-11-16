using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IJobPostingExtraSkillsService
{
    /// <summary>
    /// Create one JobPostingExtraSkill
    /// </summary>
    public Task<JobPostingExtraSkill> CreateJobPostingExtraSkill(
        JobPostingExtraSkillCreateInput jobpostingextraskill
    );

    /// <summary>
    /// Delete one JobPostingExtraSkill
    /// </summary>
    public Task DeleteJobPostingExtraSkill(JobPostingExtraSkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many JobPostingExtraSkills
    /// </summary>
    public Task<List<JobPostingExtraSkill>> JobPostingExtraSkills(
        JobPostingExtraSkillFindManyArgs findManyArgs
    );

    /// <summary>
    /// Meta data about JobPostingExtraSkill records
    /// </summary>
    public Task<MetadataDto> JobPostingExtraSkillsMeta(
        JobPostingExtraSkillFindManyArgs findManyArgs
    );

    /// <summary>
    /// Get one JobPostingExtraSkill
    /// </summary>
    public Task<JobPostingExtraSkill> JobPostingExtraSkill(
        JobPostingExtraSkillWhereUniqueInput uniqueId
    );

    /// <summary>
    /// Update one JobPostingExtraSkill
    /// </summary>
    public Task UpdateJobPostingExtraSkill(
        JobPostingExtraSkillWhereUniqueInput uniqueId,
        JobPostingExtraSkillUpdateInput updateDto
    );
}
