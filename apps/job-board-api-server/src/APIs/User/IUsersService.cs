using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IUsersService
{
    /// <summary>
    /// Create one User
    /// </summary>
    public Task<User> CreateUser(UserCreateInput user);

    /// <summary>
    /// Delete one User
    /// </summary>
    public Task DeleteUser(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Users
    /// </summary>
    public Task<List<User>> Users(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about User records
    /// </summary>
    public Task<MetadataDto> UsersMeta(UserFindManyArgs findManyArgs);

    /// <summary>
    /// Get one User
    /// </summary>
    public Task<User> User(UserWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one User
    /// </summary>
    public Task UpdateUser(UserWhereUniqueInput uniqueId, UserUpdateInput updateDto);

    /// <summary>
    /// Connect multiple Worker Profiles records to User
    /// </summary>
    public Task ConnectWorkerProfiles(
        UserWhereUniqueInput uniqueId,
        WorkerProfileWhereUniqueInput[] workerProfilesId
    );

    /// <summary>
    /// Disconnect multiple Worker Profiles records from User
    /// </summary>
    public Task DisconnectWorkerProfiles(
        UserWhereUniqueInput uniqueId,
        WorkerProfileWhereUniqueInput[] workerProfilesId
    );

    /// <summary>
    /// Find multiple Worker Profiles records for User
    /// </summary>
    public Task<List<WorkerProfile>> FindWorkerProfiles(
        UserWhereUniqueInput uniqueId,
        WorkerProfileFindManyArgs WorkerProfileFindManyArgs
    );

    /// <summary>
    /// Update multiple Worker Profiles records for User
    /// </summary>
    public Task UpdateWorkerProfiles(
        UserWhereUniqueInput uniqueId,
        WorkerProfileWhereUniqueInput[] workerProfilesId
    );
}
