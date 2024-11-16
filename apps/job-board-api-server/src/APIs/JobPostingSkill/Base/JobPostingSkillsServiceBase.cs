using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class JobPostingSkillsServiceBase : IJobPostingSkillsService
{
    protected readonly JobBoardApiDbContext _context;

    public JobPostingSkillsServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one JobPostingSkill
    /// </summary>
    public async Task<JobPostingSkill> CreateJobPostingSkill(JobPostingSkillCreateInput createDto)
    {
        var jobPostingSkill = new JobPostingSkillDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            jobPostingSkill.Id = createDto.Id;
        }

        _context.JobPostingSkills.Add(jobPostingSkill);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<JobPostingSkillDbModel>(jobPostingSkill.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one JobPostingSkill
    /// </summary>
    public async Task DeleteJobPostingSkill(JobPostingSkillWhereUniqueInput uniqueId)
    {
        var jobPostingSkill = await _context.JobPostingSkills.FindAsync(uniqueId.Id);
        if (jobPostingSkill == null)
        {
            throw new NotFoundException();
        }

        _context.JobPostingSkills.Remove(jobPostingSkill);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many JobPostingSkills
    /// </summary>
    public async Task<List<JobPostingSkill>> JobPostingSkills(
        JobPostingSkillFindManyArgs findManyArgs
    )
    {
        var jobPostingSkills = await _context
            .JobPostingSkills.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return jobPostingSkills.ConvertAll(jobPostingSkill => jobPostingSkill.ToDto());
    }

    /// <summary>
    /// Meta data about JobPostingSkill records
    /// </summary>
    public async Task<MetadataDto> JobPostingSkillsMeta(JobPostingSkillFindManyArgs findManyArgs)
    {
        var count = await _context.JobPostingSkills.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one JobPostingSkill
    /// </summary>
    public async Task<JobPostingSkill> JobPostingSkill(JobPostingSkillWhereUniqueInput uniqueId)
    {
        var jobPostingSkills = await this.JobPostingSkills(
            new JobPostingSkillFindManyArgs
            {
                Where = new JobPostingSkillWhereInput { Id = uniqueId.Id }
            }
        );
        var jobPostingSkill = jobPostingSkills.FirstOrDefault();
        if (jobPostingSkill == null)
        {
            throw new NotFoundException();
        }

        return jobPostingSkill;
    }

    /// <summary>
    /// Update one JobPostingSkill
    /// </summary>
    public async Task UpdateJobPostingSkill(
        JobPostingSkillWhereUniqueInput uniqueId,
        JobPostingSkillUpdateInput updateDto
    )
    {
        var jobPostingSkill = updateDto.ToModel(uniqueId);

        _context.Entry(jobPostingSkill).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.JobPostingSkills.Any(e => e.Id == jobPostingSkill.Id))
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
