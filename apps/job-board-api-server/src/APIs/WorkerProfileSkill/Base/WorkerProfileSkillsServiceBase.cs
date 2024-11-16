using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class WorkerProfileSkillsServiceBase : IWorkerProfileSkillsService
{
    protected readonly JobBoardApiDbContext _context;

    public WorkerProfileSkillsServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one WorkerProfileSkill
    /// </summary>
    public async Task<WorkerProfileSkill> CreateWorkerProfileSkill(
        WorkerProfileSkillCreateInput createDto
    )
    {
        var workerProfileSkill = new WorkerProfileSkillDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            workerProfileSkill.Id = createDto.Id;
        }

        _context.WorkerProfileSkills.Add(workerProfileSkill);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WorkerProfileSkillDbModel>(workerProfileSkill.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one WorkerProfileSkill
    /// </summary>
    public async Task DeleteWorkerProfileSkill(WorkerProfileSkillWhereUniqueInput uniqueId)
    {
        var workerProfileSkill = await _context.WorkerProfileSkills.FindAsync(uniqueId.Id);
        if (workerProfileSkill == null)
        {
            throw new NotFoundException();
        }

        _context.WorkerProfileSkills.Remove(workerProfileSkill);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WorkerProfileSkills
    /// </summary>
    public async Task<List<WorkerProfileSkill>> WorkerProfileSkills(
        WorkerProfileSkillFindManyArgs findManyArgs
    )
    {
        var workerProfileSkills = await _context
            .WorkerProfileSkills.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return workerProfileSkills.ConvertAll(workerProfileSkill => workerProfileSkill.ToDto());
    }

    /// <summary>
    /// Meta data about WorkerProfileSkill records
    /// </summary>
    public async Task<MetadataDto> WorkerProfileSkillsMeta(
        WorkerProfileSkillFindManyArgs findManyArgs
    )
    {
        var count = await _context.WorkerProfileSkills.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one WorkerProfileSkill
    /// </summary>
    public async Task<WorkerProfileSkill> WorkerProfileSkill(
        WorkerProfileSkillWhereUniqueInput uniqueId
    )
    {
        var workerProfileSkills = await this.WorkerProfileSkills(
            new WorkerProfileSkillFindManyArgs
            {
                Where = new WorkerProfileSkillWhereInput { Id = uniqueId.Id }
            }
        );
        var workerProfileSkill = workerProfileSkills.FirstOrDefault();
        if (workerProfileSkill == null)
        {
            throw new NotFoundException();
        }

        return workerProfileSkill;
    }

    /// <summary>
    /// Update one WorkerProfileSkill
    /// </summary>
    public async Task UpdateWorkerProfileSkill(
        WorkerProfileSkillWhereUniqueInput uniqueId,
        WorkerProfileSkillUpdateInput updateDto
    )
    {
        var workerProfileSkill = updateDto.ToModel(uniqueId);

        _context.Entry(workerProfileSkill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WorkerProfileSkills.Any(e => e.Id == workerProfileSkill.Id))
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
