using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;

namespace JobBoardApi.APIs;

public interface IJobPostingsService
{
    /// <summary>
    /// Create one Job Posting
    /// </summary>
    public Task<JobPosting> CreateJobPosting(JobPostingCreateInput jobposting);

    /// <summary>
    /// Delete one Job Posting
    /// </summary>
    public Task DeleteJobPosting(JobPostingWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Job Postings
    /// </summary>
    public Task<List<JobPosting>> JobPostings(JobPostingFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Job Posting records
    /// </summary>
    public Task<MetadataDto> JobPostingsMeta(JobPostingFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Job Posting
    /// </summary>
    public Task<JobPosting> JobPosting(JobPostingWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Job Posting
    /// </summary>
    public Task UpdateJobPosting(
        JobPostingWhereUniqueInput uniqueId,
        JobPostingUpdateInput updateDto
    );

    /// <summary>
    /// Connect multiple Applications records to Job Posting
    /// </summary>
    public Task ConnectApplications(
        JobPostingWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Disconnect multiple Applications records from Job Posting
    /// </summary>
    public Task DisconnectApplications(
        JobPostingWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );

    /// <summary>
    /// Find multiple Applications records for Job Posting
    /// </summary>
    public Task<List<Application>> FindApplications(
        JobPostingWhereUniqueInput uniqueId,
        ApplicationFindManyArgs ApplicationFindManyArgs
    );

    /// <summary>
    /// Update multiple Applications records for Job Posting
    /// </summary>
    public Task UpdateApplications(
        JobPostingWhereUniqueInput uniqueId,
        ApplicationWhereUniqueInput[] applicationsId
    );
}
