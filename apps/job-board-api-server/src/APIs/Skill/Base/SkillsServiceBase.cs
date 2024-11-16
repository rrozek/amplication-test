using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class SkillsServiceBase : ISkillsService
{
    protected readonly JobBoardApiDbContext _context;

    public SkillsServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Skill
    /// </summary>
    public async Task<Skill> CreateSkill(SkillCreateInput createDto)
    {
        var skill = new SkillDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Grading = createDto.Grading,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            skill.Id = createDto.Id;
        }

        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SkillDbModel>(skill.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Skill
    /// </summary>
    public async Task DeleteSkill(SkillWhereUniqueInput uniqueId)
    {
        var skill = await _context.Skills.FindAsync(uniqueId.Id);
        if (skill == null)
        {
            throw new NotFoundException();
        }

        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Skills
    /// </summary>
    public async Task<List<Skill>> Skills(SkillFindManyArgs findManyArgs)
    {
        var skills = await _context
            .Skills.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return skills.ConvertAll(skill => skill.ToDto());
    }

    /// <summary>
    /// Meta data about Skill records
    /// </summary>
    public async Task<MetadataDto> SkillsMeta(SkillFindManyArgs findManyArgs)
    {
        var count = await _context.Skills.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Skill
    /// </summary>
    public async Task<Skill> Skill(SkillWhereUniqueInput uniqueId)
    {
        var skills = await this.Skills(
            new SkillFindManyArgs { Where = new SkillWhereInput { Id = uniqueId.Id } }
        );
        var skill = skills.FirstOrDefault();
        if (skill == null)
        {
            throw new NotFoundException();
        }

        return skill;
    }

    /// <summary>
    /// Update one Skill
    /// </summary>
    public async Task UpdateSkill(SkillWhereUniqueInput uniqueId, SkillUpdateInput updateDto)
    {
        var skill = updateDto.ToModel(uniqueId);

        _context.Entry(skill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Skills.Any(e => e.Id == skill.Id))
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
