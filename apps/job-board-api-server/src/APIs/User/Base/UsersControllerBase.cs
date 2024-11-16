using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class UsersControllerBase : ControllerBase
{
    protected readonly IUsersService _service;

    public UsersControllerBase(IUsersService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one User
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<User>> CreateUser(UserCreateInput input)
    {
        var user = await _service.CreateUser(input);

        return CreatedAtAction(nameof(User), new { id = user.Id }, user);
    }

    /// <summary>
    /// Delete one User
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteUser([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteUser(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Users
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<User>>> Users([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.Users(filter));
    }

    /// <summary>
    /// Meta data about User records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> UsersMeta([FromQuery()] UserFindManyArgs filter)
    {
        return Ok(await _service.UsersMeta(filter));
    }

    /// <summary>
    /// Get one User
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<User>> User([FromRoute()] UserWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.User(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one User
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateUser(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] UserUpdateInput userUpdateDto
    )
    {
        try
        {
            await _service.UpdateUser(uniqueId, userUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Worker Profiles records to User
    /// </summary>
    [HttpPost("{Id}/workerProfiles")]
    public async Task<ActionResult> ConnectWorkerProfiles(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WorkerProfileWhereUniqueInput[] workerProfilesId
    )
    {
        try
        {
            await _service.ConnectWorkerProfiles(uniqueId, workerProfilesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Worker Profiles records from User
    /// </summary>
    [HttpDelete("{Id}/workerProfiles")]
    public async Task<ActionResult> DisconnectWorkerProfiles(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WorkerProfileWhereUniqueInput[] workerProfilesId
    )
    {
        try
        {
            await _service.DisconnectWorkerProfiles(uniqueId, workerProfilesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Worker Profiles records for User
    /// </summary>
    [HttpGet("{Id}/workerProfiles")]
    public async Task<ActionResult<List<WorkerProfile>>> FindWorkerProfiles(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromQuery()] WorkerProfileFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkerProfiles(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple Worker Profiles records for User
    /// </summary>
    [HttpPatch("{Id}/workerProfiles")]
    public async Task<ActionResult> UpdateWorkerProfiles(
        [FromRoute()] UserWhereUniqueInput uniqueId,
        [FromBody()] WorkerProfileWhereUniqueInput[] workerProfilesId
    )
    {
        try
        {
            await _service.UpdateWorkerProfiles(uniqueId, workerProfilesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
