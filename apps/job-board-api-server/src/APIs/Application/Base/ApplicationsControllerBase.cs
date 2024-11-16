using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ApplicationsControllerBase : ControllerBase
{
    protected readonly IApplicationsService _service;

    public ApplicationsControllerBase(IApplicationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Application
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Application>> CreateApplication(ApplicationCreateInput input)
    {
        var application = await _service.CreateApplication(input);

        return CreatedAtAction(nameof(Application), new { id = application.Id }, application);
    }

    /// <summary>
    /// Delete one Application
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteApplication(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteApplication(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Applications
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Application>>> Applications(
        [FromQuery()] ApplicationFindManyArgs filter
    )
    {
        return Ok(await _service.Applications(filter));
    }

    /// <summary>
    /// Meta data about Application records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ApplicationsMeta(
        [FromQuery()] ApplicationFindManyArgs filter
    )
    {
        return Ok(await _service.ApplicationsMeta(filter));
    }

    /// <summary>
    /// Get one Application
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Application>> Application(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Application(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Application
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateApplication(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId,
        [FromQuery()] ApplicationUpdateInput applicationUpdateDto
    )
    {
        try
        {
            await _service.UpdateApplication(uniqueId, applicationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a jobPosting record for Application
    /// </summary>
    [HttpGet("{Id}/jobPosting")]
    public async Task<ActionResult<List<JobPosting>>> GetJobPosting(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        var jobPosting = await _service.GetJobPosting(uniqueId);
        return Ok(jobPosting);
    }

    /// <summary>
    /// Get a workerProfile record for Application
    /// </summary>
    [HttpGet("{Id}/workerProfile")]
    public async Task<ActionResult<List<WorkerProfile>>> GetWorkerProfile(
        [FromRoute()] ApplicationWhereUniqueInput uniqueId
    )
    {
        var workerProfile = await _service.GetWorkerProfile(uniqueId);
        return Ok(workerProfile);
    }
}
