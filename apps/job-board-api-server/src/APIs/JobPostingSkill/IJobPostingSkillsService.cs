using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IJobPostingSkillsService
{
    /// <summary>
    /// Create one JobPostingSkill
    /// </summary>
    public Task<JobPostingSkill> CreateJobPostingSkill(JobPostingSkillCreateInput jobpostingskill);

    /// <summary>
    /// Delete one JobPostingSkill
    /// </summary>
    public Task DeleteJobPostingSkill(JobPostingSkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many JobPostingSkills
    /// </summary>
    public Task<List<JobPostingSkill>> JobPostingSkills(JobPostingSkillFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about JobPostingSkill records
    /// </summary>
    public Task<MetadataDto> JobPostingSkillsMeta(JobPostingSkillFindManyArgs findManyArgs);

    /// <summary>
    /// Get one JobPostingSkill
    /// </summary>
    public Task<JobPostingSkill> JobPostingSkill(JobPostingSkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one JobPostingSkill
    /// </summary>
    public Task UpdateJobPostingSkill(
        JobPostingSkillWhereUniqueInput uniqueId,
        JobPostingSkillUpdateInput updateDto
    );
}
