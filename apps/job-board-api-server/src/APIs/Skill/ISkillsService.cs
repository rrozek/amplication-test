using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface ISkillsService
{
    /// <summary>
    /// Create one Skill
    /// </summary>
    public Task<Skill> CreateSkill(SkillCreateInput skill);

    /// <summary>
    /// Delete one Skill
    /// </summary>
    public Task DeleteSkill(SkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Skills
    /// </summary>
    public Task<List<Skill>> Skills(SkillFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Skill records
    /// </summary>
    public Task<MetadataDto> SkillsMeta(SkillFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Skill
    /// </summary>
    public Task<Skill> Skill(SkillWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Skill
    /// </summary>
    public Task UpdateSkill(SkillWhereUniqueInput uniqueId, SkillUpdateInput updateDto);
}
