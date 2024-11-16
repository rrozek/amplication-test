using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WorkerProfilesControllerBase : ControllerBase
{
    protected readonly IWorkerProfilesService _service;

    public WorkerProfilesControllerBase(IWorkerProfilesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Worker Profile
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WorkerProfile>> CreateWorkerProfile(
        WorkerProfileCreateInput input
    )
    {
        var workerProfile = await _service.CreateWorkerProfile(input);

        return CreatedAtAction(nameof(WorkerProfile), new { id = workerProfile.Id }, workerProfile);
    }

    /// <summary>
    /// Delete one Worker Profile
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWorkerProfile(
        [FromRoute()] WorkerProfileWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWorkerProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Worker Profiles
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WorkerProfile>>> WorkerProfiles(
        [FromQuery()] WorkerProfileFindManyArgs filter
    )
    {
        return Ok(await _service.WorkerProfiles(filter));
    }

    /// <summary>
    /// Meta data about Worker Profile records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WorkerProfilesMeta(
        [FromQuery()] WorkerProfileFindManyArgs filter
    )
    {
        return Ok(await _service.WorkerProfilesMeta(filter));
    }

    /// <summary>
    /// Get one Worker Profile
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WorkerProfile>> WorkerProfile(
        [FromRoute()] WorkerProfileWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WorkerProfile(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Worker Profile
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWorkerProfile(
        [FromRoute()] WorkerProfileWhereUniqueInput uniqueId,
        [FromQuery()] WorkerProfileUpdateInput workerProfileUpdateDto
    )
    {
        try
        {
            await _service.UpdateWorkerProfile(uniqueId, workerProfileUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Applications records to Worker Profile
    /// </summary>
    [HttpPost("{Id}/applications")]
    public async Task<ActionResult> ConnectApplications(
        [FromRoute()] WorkerProfileWhereUniqueInput uniqueId,
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
    /// Disconnect multiple Applications records from Worker Profile
    /// </summary>
    [HttpDelete("{Id}/applications")]
    public async Task<ActionResult> DisconnectApplications(
        [FromRoute()] WorkerProfileWhereUniqueInput uniqueId,
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
    /// Find multiple Applications records for Worker Profile
    /// </summary>
    [HttpGet("{Id}/applications")]
    public async Task<ActionResult<List<Application>>> FindApplications(
        [FromRoute()] WorkerProfileWhereUniqueInput uniqueId,
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
    /// Update multiple Applications records for Worker Profile
    /// </summary>
    [HttpPatch("{Id}/applications")]
    public async Task<ActionResult> UpdateApplications(
        [FromRoute()] WorkerProfileWhereUniqueInput uniqueId,
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

    /// <summary>
    /// Get a user record for Worker Profile
    /// </summary>
    [HttpGet("{Id}/user")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] WorkerProfileWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }
}
