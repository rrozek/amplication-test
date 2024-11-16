using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class ExtraSkillsServiceBase : IExtraSkillsService
{
    protected readonly JobBoardApiDbContext _context;

    public ExtraSkillsServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Extra Skill
    /// </summary>
    public async Task<ExtraSkill> CreateExtraSkill(ExtraSkillCreateInput createDto)
    {
        var extraSkill = new ExtraSkillDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            extraSkill.Id = createDto.Id;
        }

        _context.ExtraSkills.Add(extraSkill);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ExtraSkillDbModel>(extraSkill.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Extra Skill
    /// </summary>
    public async Task DeleteExtraSkill(ExtraSkillWhereUniqueInput uniqueId)
    {
        var extraSkill = await _context.ExtraSkills.FindAsync(uniqueId.Id);
        if (extraSkill == null)
        {
            throw new NotFoundException();
        }

        _context.ExtraSkills.Remove(extraSkill);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Extra Skills
    /// </summary>
    public async Task<List<ExtraSkill>> ExtraSkills(ExtraSkillFindManyArgs findManyArgs)
    {
        var extraSkills = await _context
            .ExtraSkills.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return extraSkills.ConvertAll(extraSkill => extraSkill.ToDto());
    }

    /// <summary>
    /// Meta data about Extra Skill records
    /// </summary>
    public async Task<MetadataDto> ExtraSkillsMeta(ExtraSkillFindManyArgs findManyArgs)
    {
        var count = await _context.ExtraSkills.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Extra Skill
    /// </summary>
    public async Task<ExtraSkill> ExtraSkill(ExtraSkillWhereUniqueInput uniqueId)
    {
        var extraSkills = await this.ExtraSkills(
            new ExtraSkillFindManyArgs { Where = new ExtraSkillWhereInput { Id = uniqueId.Id } }
        );
        var extraSkill = extraSkills.FirstOrDefault();
        if (extraSkill == null)
        {
            throw new NotFoundException();
        }

        return extraSkill;
    }

    /// <summary>
    /// Update one Extra Skill
    /// </summary>
    public async Task UpdateExtraSkill(
        ExtraSkillWhereUniqueInput uniqueId,
        ExtraSkillUpdateInput updateDto
    )
    {
        var extraSkill = updateDto.ToModel(uniqueId);

        _context.Entry(extraSkill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ExtraSkills.Any(e => e.Id == extraSkill.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
