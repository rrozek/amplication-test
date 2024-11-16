using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class JobPostingsServiceBase : IJobPostingsService
{
    protected readonly JobBoardApiDbContext _context;

    public JobPostingsServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Job Posting
    /// </summary>
    public async Task<JobPosting> CreateJobPosting(JobPostingCreateInput createDto)
    {
        var jobPosting = new JobPostingDbModel
        {
            Agency = createDto.Agency,
            AnalyticsApplications = createDto.AnalyticsApplications,
            AnalyticsClicks = createDto.AnalyticsClicks,
            AnalyticsViews = createDto.AnalyticsViews,
            CreatedAt = createDto.CreatedAt,
            Location = createDto.Location,
            SalaryMax = createDto.SalaryMax,
            SalaryMin = createDto.SalaryMin,
            Title = createDto.Title,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            jobPosting.Id = createDto.Id;
        }
        if (createDto.Applications != null)
        {
            jobPosting.Applications = await _context
                .Applications.Where(application =>
                    createDto.Applications.Select(t => t.Id).Contains(application.Id)
                )
                .ToListAsync();
        }

        _context.JobPostings.Add(jobPosting);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<JobPostingDbModel>(jobPosting.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Job Posting
    /// </summary>
    public async Task DeleteJobPosting(JobPostingWhereUniqueInput uniqueId)
    {
        var jobPosting = await _context.JobPostings.FindAsync(uniqueId.Id);
        if (jobPosting == null)
        {
            throw new NotFoundException();
        }

        _context.JobPostings.Remove(jobPosting);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Job Postings
    /// </summary>
    public async Task<List<JobPosting>> JobPostings(JobPostingFindManyArgs findManyArgs)
    {
        var jobPostings = await _context
            .JobPostings.Include(x => x.Applications)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return jobPostings.ConvertAll(jobPosting => jobPosting.ToDto());
    }

    /// <summary>
    /// Meta data about Job Posting records
    /// </summary>
    public async Task<MetadataDto> JobPostingsMeta(JobPostingFindManyArgs findManyArgs)
    {
        var count = await _context.JobPostings.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Job Posting
    /// </summary>
    public async Task<JobPosting> JobPosting(JobPostingWhereUniqueInput uniqueId)
    {
        var jobPostings = await this.JobPostings(
            new JobPostingFindManyArgs { Where = new JobPostingWhereInput { Id = uniqueId.Id } }
        );
        var jobPosting = jobPostings.FirstOrDefault();
        if (jobPosting == null)
        {
            throw new NotFoundException();
        }

        return jobPosting;
    }

    /// <summary>
    /// Update one Job Posting
    /// </summary>
    public async Task UpdateJobPosting(
        JobPostingWhereUniqueInput uniqueId,
        JobPostingUpdateInput updateDto
    )
    {
        var jobPosting = updateDto.ToModel(uniqueId);

        if (updateDto.Applications != null)
        {
            jobPosting.Applications = await _context
                .Applications.Where(application =>
                    updateDto.Applications.Select(t => t).Contains(application.Id)
                )
                .ToListAsync();
        }

        _context.Entry(jobPosting).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.JobPostings.Any(e => e.Id == jobPosting.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Connect multiple Applications records to Job Posting
    /// </summary>
    public async Task ConnectApplications(
        JobPostingWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .JobPostings.Include(x => x.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Applications.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.Applications);

        foreach (var child in childrenToConnect)
        {
            parent.Applications.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Applications records from Job Posting
    /// </summary>
    public async Task DisconnectApplications(
        JobPostingWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .JobPostings.Include(x => x.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Applications.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var child in children)
        {
            parent.Applications?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Applications records for Job Posting
    /// </summary>
    public async Task<List<Application>> FindApplications(
        JobPostingWhereUniqueInput uniqueId,
        ApplicationFindManyArgs jobPostingFindManyArgs
    )
    {
        var applications = await _context
            .Applications.Where(m => m.JobPostingId == uniqueId.Id)
            .ApplyWhere(jobPostingFindManyArgs.Where)
            .ApplySkip(jobPostingFindManyArgs.Skip)
            .ApplyTake(jobPostingFindManyArgs.Take)
            .ApplyOrderBy(jobPostingFindManyArgs.SortBy)
            .ToListAsync();

        return applications.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Applications records for Job Posting
    /// </summary>
    public async Task UpdateApplications(
        JobPostingWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var jobPosting = await _context
            .JobPostings.Include(t => t.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (jobPosting == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
            .Applications.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        jobPosting.Applications = children;
        await _context.SaveChangesAsync();
    }
}
