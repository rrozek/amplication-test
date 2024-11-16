using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IExtraSkillsService
{
    /// <summary>
    /// Create one Extra Skill
    /// </summary>
    public Task<ExtraSkill> CreateExtraSkill(ExtraSkillCreateInput extraskill);

    /// <summary>
    /// Delete one Extra Skill
    /// </summary>
    public Task DeleteExtraSkill(ExtraSkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Extra Skills
    /// </summary>
    public Task<List<ExtraSkill>> ExtraSkills(ExtraSkillFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Extra Skill records
    /// </summary>
    public Task<MetadataDto> ExtraSkillsMeta(ExtraSkillFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Extra Skill
    /// </summary>
    public Task<ExtraSkill> ExtraSkill(ExtraSkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Extra Skill
    /// </summary>
    public Task UpdateExtraSkill(
        ExtraSkillWhereUniqueInput uniqueId,
        ExtraSkillUpdateInput updateDto
    );
}
