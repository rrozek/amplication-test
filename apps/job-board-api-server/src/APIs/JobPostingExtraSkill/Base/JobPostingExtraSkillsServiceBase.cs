using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class JobPostingExtraSkillsServiceBase : IJobPostingExtraSkillsService
{
    protected readonly JobBoardApiDbContext _context;

    public JobPostingExtraSkillsServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one JobPostingExtraSkill
    /// </summary>
    public async Task<JobPostingExtraSkill> CreateJobPostingExtraSkill(
        JobPostingExtraSkillCreateInput createDto
    )
    {
        var jobPostingExtraSkill = new JobPostingExtraSkillDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            jobPostingExtraSkill.Id = createDto.Id;
        }

        _context.JobPostingExtraSkills.Add(jobPostingExtraSkill);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<JobPostingExtraSkillDbModel>(jobPostingExtraSkill.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one JobPostingExtraSkill
    /// </summary>
    public async Task DeleteJobPostingExtraSkill(JobPostingExtraSkillWhereUniqueInput uniqueId)
    {
        var jobPostingExtraSkill = await _context.JobPostingExtraSkills.FindAsync(uniqueId.Id);
        if (jobPostingExtraSkill == null)
        {
            throw new NotFoundException();
        }

        _context.JobPostingExtraSkills.Remove(jobPostingExtraSkill);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many JobPostingExtraSkills
    /// </summary>
    public async Task<List<JobPostingExtraSkill>> JobPostingExtraSkills(
        JobPostingExtraSkillFindManyArgs findManyArgs
    )
    {
        var jobPostingExtraSkills = await _context
            .JobPostingExtraSkills.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return jobPostingExtraSkills.ConvertAll(jobPostingExtraSkill =>
            jobPostingExtraSkill.ToDto()
        );
    }

    /// <summary>
    /// Meta data about JobPostingExtraSkill records
    /// </summary>
    public async Task<MetadataDto> JobPostingExtraSkillsMeta(
        JobPostingExtraSkillFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .JobPostingExtraSkills.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one JobPostingExtraSkill
    /// </summary>
    public async Task<JobPostingExtraSkill> JobPostingExtraSkill(
        JobPostingExtraSkillWhereUniqueInput uniqueId
    )
    {
        var jobPostingExtraSkills = await this.JobPostingExtraSkills(
            new JobPostingExtraSkillFindManyArgs
            {
                Where = new JobPostingExtraSkillWhereInput { Id = uniqueId.Id }
            }
        );
        var jobPostingExtraSkill = jobPostingExtraSkills.FirstOrDefault();
        if (jobPostingExtraSkill == null)
        {
            throw new NotFoundException();
        }

        return jobPostingExtraSkill;
    }

    /// <summary>
    /// Update one JobPostingExtraSkill
    /// </summary>
    public async Task UpdateJobPostingExtraSkill(
        JobPostingExtraSkillWhereUniqueInput uniqueId,
        JobPostingExtraSkillUpdateInput updateDto
    )
    {
        var jobPostingExtraSkill = updateDto.ToModel(uniqueId);

        _context.Entry(jobPostingExtraSkill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.JobPostingExtraSkills.Any(e => e.Id == jobPostingExtraSkill.Id))
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
