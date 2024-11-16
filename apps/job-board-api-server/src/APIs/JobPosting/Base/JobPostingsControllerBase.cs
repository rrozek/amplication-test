using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class JobPostingsControllerBase : ControllerBase
{
    protected readonly IJobPostingsService _service;

    public JobPostingsControllerBase(IJobPostingsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Job Posting
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<JobPosting>> CreateJobPosting(JobPostingCreateInput input)
    {
        var jobPosting = await _service.CreateJobPosting(input);

        return CreatedAtAction(nameof(JobPosting), new { id = jobPosting.Id }, jobPosting);
    }

    /// <summary>
    /// Delete one Job Posting
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteJobPosting(
        [FromRoute()] JobPostingWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteJobPosting(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Job Postings
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<JobPosting>>> JobPostings(
        [FromQuery()] JobPostingFindManyArgs filter
    )
    {
        return Ok(await _service.JobPostings(filter));
    }

    /// <summary>
    /// Meta data about Job Posting records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> JobPostingsMeta(
        [FromQuery()] JobPostingFindManyArgs filter
    )
    {
        return Ok(await _service.JobPostingsMeta(filter));
    }

    /// <summary>
    /// Get one Job Posting
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<JobPosting>> JobPosting(
        [FromRoute()] JobPostingWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.JobPosting(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Job Posting
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateJobPosting(
        [FromRoute()] JobPostingWhereUniqueInput uniqueId,
        [FromQuery()] JobPostingUpdateInput jobPostingUpdateDto
    )
    {
        try
        {
            await _service.UpdateJobPosting(uniqueId, jobPostingUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Applications records to Job Posting
    /// </summary>
    [HttpPost("{Id}/applications")]
    public async Task<ActionResult> ConnectApplications(
        [FromRoute()] JobPostingWhereUniqueInput uniqueId,
        [FromQuery()] ApplicationWhereUniqueInput[] applicationsId
    )
    {
        try
        {
            await _service.ConnectApplications(uniqueId, applicationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Applications records from Job Posting
    /// </summary>
    [HttpDelete("{Id}/applications")]
    public async Task<ActionResult> DisconnectApplications(
        [FromRoute()] JobPostingWhereUniqueInput uniqueId,
        [FromBody()] ApplicationWhereUniqueInput[] applicationsId
    )
    {
        try
        {
            await _service.DisconnectApplications(uniqueId, applicationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Applications records for Job Posting
    /// </summary>
    [HttpGet("{Id}/applications")]
    public async Task<ActionResult<List<Application>>> FindApplications(
        [FromRoute()] JobPostingWhereUniqueInput uniqueId,
        [FromQuery()] ApplicationFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindApplications(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Applications records for Job Posting
    /// </summary>
    [HttpPatch("{Id}/applications")]
    public async Task<ActionResult> UpdateApplications(
        [FromRoute()] JobPostingWhereUniqueInput uniqueId,
        [FromBody()] ApplicationWhereUniqueInput[] applicationsId
    )
    {
        try
        {
            await _service.UpdateApplications(uniqueId, applicationsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
