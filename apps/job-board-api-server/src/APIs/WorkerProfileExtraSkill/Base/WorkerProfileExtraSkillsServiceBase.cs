using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class WorkerProfileExtraSkillsServiceBase : IWorkerProfileExtraSkillsService
{
    protected readonly JobBoardApiDbContext _context;

    public WorkerProfileExtraSkillsServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one WorkerProfileExtraSkill
    /// </summary>
    public async Task<WorkerProfileExtraSkill> CreateWorkerProfileExtraSkill(
        WorkerProfileExtraSkillCreateInput createDto
    )
    {
        var workerProfileExtraSkill = new WorkerProfileExtraSkillDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            workerProfileExtraSkill.Id = createDto.Id;
        }

        _context.WorkerProfileExtraSkills.Add(workerProfileExtraSkill);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WorkerProfileExtraSkillDbModel>(
            workerProfileExtraSkill.Id
        );

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one WorkerProfileExtraSkill
    /// </summary>
    public async Task DeleteWorkerProfileExtraSkill(
        WorkerProfileExtraSkillWhereUniqueInput uniqueId
    )
    {
        var workerProfileExtraSkill = await _context.WorkerProfileExtraSkills.FindAsync(
            uniqueId.Id
        );
        if (workerProfileExtraSkill == null)
        {
            throw new NotFoundException();
        }

        _context.WorkerProfileExtraSkills.Remove(workerProfileExtraSkill);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WorkerProfileExtraSkills
    /// </summary>
    public async Task<List<WorkerProfileExtraSkill>> WorkerProfileExtraSkills(
        WorkerProfileExtraSkillFindManyArgs findManyArgs
    )
    {
        var workerProfileExtraSkills = await _context
            .WorkerProfileExtraSkills.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return workerProfileExtraSkills.ConvertAll(workerProfileExtraSkill =>
            workerProfileExtraSkill.ToDto()
        );
    }

    /// <summary>
    /// Meta data about WorkerProfileExtraSkill records
    /// </summary>
    public async Task<MetadataDto> WorkerProfileExtraSkillsMeta(
        WorkerProfileExtraSkillFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .WorkerProfileExtraSkills.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one WorkerProfileExtraSkill
    /// </summary>
    public async Task<WorkerProfileExtraSkill> WorkerProfileExtraSkill(
        WorkerProfileExtraSkillWhereUniqueInput uniqueId
    )
    {
        var workerProfileExtraSkills = await this.WorkerProfileExtraSkills(
            new WorkerProfileExtraSkillFindManyArgs
            {
                Where = new WorkerProfileExtraSkillWhereInput { Id = uniqueId.Id }
            }
        );
        var workerProfileExtraSkill = workerProfileExtraSkills.FirstOrDefault();
        if (workerProfileExtraSkill == null)
        {
            throw new NotFoundException();
        }

        return workerProfileExtraSkill;
    }

    /// <summary>
    /// Update one WorkerProfileExtraSkill
    /// </summary>
    public async Task UpdateWorkerProfileExtraSkill(
        WorkerProfileExtraSkillWhereUniqueInput uniqueId,
        WorkerProfileExtraSkillUpdateInput updateDto
    )
    {
        var workerProfileExtraSkill = updateDto.ToModel(uniqueId);

        _context.Entry(workerProfileExtraSkill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WorkerProfileExtraSkills.Any(e => e.Id == workerProfileExtraSkill.Id))
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
