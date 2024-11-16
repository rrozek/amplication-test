using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IApplicationsService
{
    /// <summary>
    /// Create one Application
    /// </summary>
    public Task<Application> CreateApplication(ApplicationCreateInput application);

    /// <summary>
    /// Delete one Application
    /// </summary>
    public Task DeleteApplication(ApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Applications
    /// </summary>
    public Task<List<Application>> Applications(ApplicationFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Application records
    /// </summary>
    public Task<MetadataDto> ApplicationsMeta(ApplicationFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Application
    /// </summary>
    public Task<Application> Application(ApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Application
    /// </summary>
    public Task UpdateApplication(
        ApplicationWhereUniqueInput uniqueId,
        ApplicationUpdateInput updateDto
    );

    /// <summary>
    /// Get a jobPosting record for Application
    /// </summary>
    public Task<JobPosting> GetJobPosting(ApplicationWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a workerProfile record for Application
    /// </summary>
    public Task<WorkerProfile> GetWorkerProfile(ApplicationWhereUniqueInput uniqueId);
}
