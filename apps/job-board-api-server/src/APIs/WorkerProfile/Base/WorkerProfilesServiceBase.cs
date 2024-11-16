using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using JobBoardApi.APIs.Extensions;
using JobBoardApi.Infrastructure;
using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.APIs;

public abstract class WorkerProfilesServiceBase : IWorkerProfilesService
{
    protected readonly JobBoardApiDbContext _context;

    public WorkerProfilesServiceBase(JobBoardApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Worker Profile
    /// </summary>
    public async Task<WorkerProfile> CreateWorkerProfile(WorkerProfileCreateInput createDto)
    {
        var workerProfile = new WorkerProfileDbModel
        {
            Age = createDto.Age,
            Availability = createDto.Availability,
            ContactEmail = createDto.ContactEmail,
            ContactPhone = createDto.ContactPhone,
            CreatedAt = createDto.CreatedAt,
            Gender = createDto.Gender,
            Name = createDto.Name,
            SalaryExpectation = createDto.SalaryExpectation,
            SalaryMax = createDto.SalaryMax,
            SalaryMin = createDto.SalaryMin,
            UpdatedAt = createDto.UpdatedAt,
            WillingnessToWorkAbroad = createDto.WillingnessToWorkAbroad
        };

        if (createDto.Id != null)
        {
            workerProfile.Id = createDto.Id;
        }
        if (createDto.Applications != null)
        {
            workerProfile.Applications = await _context
                .Applications.Where(application =>
                    createDto.Applications.Select(t => t.Id).Contains(application.Id)
                )
                .ToListAsync();
        }

        if (createDto.User != null)
        {
            workerProfile.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.WorkerProfiles.Add(workerProfile);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WorkerProfileDbModel>(workerProfile.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Worker Profile
    /// </summary>
    public async Task DeleteWorkerProfile(WorkerProfileWhereUniqueInput uniqueId)
    {
        var workerProfile = await _context.WorkerProfiles.FindAsync(uniqueId.Id);
        if (workerProfile == null)
        {
            throw new NotFoundException();
        }

        _context.WorkerProfiles.Remove(workerProfile);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Worker Profiles
    /// </summary>
    public async Task<List<WorkerProfile>> WorkerProfiles(WorkerProfileFindManyArgs findManyArgs)
    {
        var workerProfiles = await _context
            .WorkerProfiles.Include(x => x.Applications)
            .Include(x => x.User)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return workerProfiles.ConvertAll(workerProfile => workerProfile.ToDto());
    }

    /// <summary>
    /// Meta data about Worker Profile records
    /// </summary>
    public async Task<MetadataDto> WorkerProfilesMeta(WorkerProfileFindManyArgs findManyArgs)
    {
        var count = await _context.WorkerProfiles.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Worker Profile
    /// </summary>
    public async Task<WorkerProfile> WorkerProfile(WorkerProfileWhereUniqueInput uniqueId)
    {
        var workerProfiles = await this.WorkerProfiles(
            new WorkerProfileFindManyArgs
            {
                Where = new WorkerProfileWhereInput { Id = uniqueId.Id }
            }
        );
        var workerProfile = workerProfiles.FirstOrDefault();
        if (workerProfile == null)
        {
            throw new NotFoundException();
        }

        return workerProfile;
    }

    /// <summary>
    /// Update one Worker Profile
    /// </summary>
    public async Task UpdateWorkerProfile(
        WorkerProfileWhereUniqueInput uniqueId,
        WorkerProfileUpdateInput updateDto
    )
    {
        var workerProfile = updateDto.ToModel(uniqueId);

        if (updateDto.Applications != null)
        {
            workerProfile.Applications = await _context
                .Applications.Where(application =>
                    updateDto.Applications.Select(t => t).Contains(application.Id)
                )
                .ToListAsync();
        }

        if (updateDto.User != null)
        {
            workerProfile.User = await _context
                .Users.Where(user => updateDto.User == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(workerProfile).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WorkerProfiles.Any(e => e.Id == workerProfile.Id))
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
    /// Connect multiple Applications records to Worker Profile
    /// </summary>
    public async Task ConnectApplications(
        WorkerProfileWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .WorkerProfiles.Include(x => x.Applications)
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
    /// Disconnect multiple Applications records from Worker Profile
    /// </summary>
    public async Task DisconnectApplications(
        WorkerProfileWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var parent = await _context
            .WorkerProfiles.Include(x => x.Applications)
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
    /// Find multiple Applications records for Worker Profile
    /// </summary>
    public async Task<List<Application>> FindApplications(
        WorkerProfileWhereUniqueInput uniqueId,
        ApplicationFindManyArgs workerProfileFindManyArgs
    )
    {
        var applications = await _context
            .Applications.Where(m => m.WorkerProfileId == uniqueId.Id)
            .ApplyWhere(workerProfileFindManyArgs.Where)
            .ApplySkip(workerProfileFindManyArgs.Skip)
            .ApplyTake(workerProfileFindManyArgs.Take)
            .ApplyOrderBy(workerProfileFindManyArgs.SortBy)
            .ToListAsync();

        return applications.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple Applications records for Worker Profile
    /// </summary>
    public async Task UpdateApplications(
        WorkerProfileWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] childrenIds
    )
    {
        var workerProfile = await _context
            .WorkerProfiles.Include(t => t.Applications)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workerProfile == null)
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

        workerProfile.Applications = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Get a user record for Worker Profile
    /// </summary>
    public async Task<User> GetUser(WorkerProfileWhereUniqueInput uniqueId)
    {
        var workerProfile = await _context
            .WorkerProfiles.Where(workerProfile => workerProfile.Id == uniqueId.Id)
            .Include(workerProfile => workerProfile.User)
            .FirstOrDefaultAsync();
        if (workerProfile == null)
        {
            throw new NotFoundException();
        }
        return workerProfile.User.ToDto();
    }
}
