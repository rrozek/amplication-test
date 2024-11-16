using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class ApplicationsServiceBase : IApplicationsService
{
    protected readonly JobBoardApiDbContext _context;

    public ApplicationsServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Application
    /// </summary>
    public async Task<Application> CreateApplication(ApplicationCreateInput createDto)
    {
        var application = new ApplicationDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Status = createDto.Status,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            application.Id = createDto.Id;
        }
        if (createDto.JobPosting != null)
        {
            application.JobPosting = await _context
                .JobPostings.Where(jobPosting => createDto.JobPosting.Id == jobPosting.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.WorkerProfile != null)
        {
            application.WorkerProfile = await _context
                .WorkerProfiles.Where(workerProfile =>
                    createDto.WorkerProfile.Id == workerProfile.Id
                )
                .FirstOrDefaultAsync();
        }

        _context.Applications.Add(application);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ApplicationDbModel>(application.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Application
    /// </summary>
    public async Task DeleteApplication(ApplicationWhereUniqueInput uniqueId)
    {
        var application = await _context.Applications.FindAsync(uniqueId.Id);
        if (application == null)
        {
            throw new NotFoundException();
        }

        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Applications
    /// </summary>
    public async Task<List<Application>> Applications(ApplicationFindManyArgs findManyArgs)
    {
        var applications = await _context
            .Applications.Include(x => x.WorkerProfile)
            .Include(x => x.JobPosting)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return applications.ConvertAll(application => application.ToDto());
    }

    /// <summary>
    /// Meta data about Application records
    /// </summary>
    public async Task<MetadataDto> ApplicationsMeta(ApplicationFindManyArgs findManyArgs)
    {
        var count = await _context.Applications.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Application
    /// </summary>
    public async Task<Application> Application(ApplicationWhereUniqueInput uniqueId)
    {
        var applications = await this.Applications(
            new ApplicationFindManyArgs { Where = new ApplicationWhereInput { Id = uniqueId.Id } }
        );
        var application = applications.FirstOrDefault();
        if (application == null)
        {
            throw new NotFoundException();
        }

        return application;
    }

    /// <summary>
    /// Update one Application
    /// </summary>
    public async Task UpdateApplication(
        ApplicationWhereUniqueInput uniqueId,
        ApplicationUpdateInput updateDto
    )
    {
        var application = updateDto.ToModel(uniqueId);

        if (updateDto.JobPosting != null)
        {
            application.JobPosting = await _context
                .JobPostings.Where(jobPosting => updateDto.JobPosting == jobPosting.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.WorkerProfile != null)
        {
            application.WorkerProfile = await _context
                .WorkerProfiles.Where(workerProfile => updateDto.WorkerProfile == workerProfile.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(application).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Applications.Any(e => e.Id == application.Id))
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
    /// Get a jobPosting record for Application
    /// </summary>
    public async Task<JobPosting> GetJobPosting(ApplicationWhereUniqueInput uniqueId)
    {
        var application = await _context
            .Applications.Where(application => application.Id == uniqueId.Id)
            .Include(application => application.JobPosting)
            .FirstOrDefaultAsync();
        if (application == null)
        {
            throw new NotFoundException();
        }
        return application.JobPosting.ToDto();
    }

    /// <summary>
    /// Get a workerProfile record for Application
    /// </summary>
    public async Task<WorkerProfile> GetWorkerProfile(ApplicationWhereUniqueInput uniqueId)
    {
        var application = await _context
            .Applications.Where(application => application.Id == uniqueId.Id)
            .Include(application => application.WorkerProfile)
            .FirstOrDefaultAsync();
        if (application == null)
        {
            throw new NotFoundException();
        }
        return application.WorkerProfile.ToDto();
    }
}
