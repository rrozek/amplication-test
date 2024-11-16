using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IWorkerProfilesService
{
    /// <summary>
    /// Create one Worker Profile
    /// </summary>
    public Task<WorkerProfile> CreateWorkerProfile(WorkerProfileCreateInput workerprofile);

    /// <summary>
    /// Delete one Worker Profile
    /// </summary>
    public Task DeleteWorkerProfile(WorkerProfileWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Worker Profiles
    /// </summary>
    public Task<List<WorkerProfile>> WorkerProfiles(WorkerProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Worker Profile records
    /// </summary>
    public Task<MetadataDto> WorkerProfilesMeta(WorkerProfileFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Worker Profile
    /// </summary>
    public Task<WorkerProfile> WorkerProfile(WorkerProfileWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Worker Profile
    /// </summary>
    public Task UpdateWorkerProfile(
        WorkerProfileWhereUniqueInput uniqueId,
        WorkerProfileUpdateInput updateDto
    );

    /// <summary>
    /// Connect multiple Applications records to Worker Profile
    /// </summary>
    public Task ConnectApplications(
        WorkerProfileWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Disconnect multiple Applications records from Worker Profile
    /// </summary>
    public Task DisconnectApplications(
        WorkerProfileWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Find multiple Applications records for Worker Profile
    /// </summary>
    public Task<List<Application>> FindApplications(
        WorkerProfileWhereUniqueInput uniqueId,
        ApplicationFindManyArgs ApplicationFindManyArgs
    );

    /// <summary>
    /// Update multiple Applications records for Worker Profile
    /// </summary>
    public Task UpdateApplications(
        WorkerProfileWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Get a user record for Worker Profile
    /// </summary>
    public Task<User> GetUser(WorkerProfileWhereUniqueInput uniqueId);
}
