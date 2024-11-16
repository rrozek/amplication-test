using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WorkerProfileSkillsControllerBase : ControllerBase
{
    protected readonly IWorkerProfileSkillsService _service;

    public WorkerProfileSkillsControllerBase(IWorkerProfileSkillsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one WorkerProfileSkill
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WorkerProfileSkill>> CreateWorkerProfileSkill(
        WorkerProfileSkillCreateInput input
    )
    {
        var workerProfileSkill = await _service.CreateWorkerProfileSkill(input);

        return CreatedAtAction(
            nameof(WorkerProfileSkill),
            new { id = workerProfileSkill.Id },
            workerProfileSkill
        );
    }

    /// <summary>
    /// Delete one WorkerProfileSkill
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWorkerProfileSkill(
        [FromRoute()] WorkerProfileSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWorkerProfileSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WorkerProfileSkills
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WorkerProfileSkill>>> WorkerProfileSkills(
        [FromQuery()] WorkerProfileSkillFindManyArgs filter
    )
    {
        return Ok(await _service.WorkerProfileSkills(filter));
    }

    /// <summary>
    /// Meta data about WorkerProfileSkill records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WorkerProfileSkillsMeta(
        [FromQuery()] WorkerProfileSkillFindManyArgs filter
    )
    {
        return Ok(await _service.WorkerProfileSkillsMeta(filter));
    }

    /// <summary>
    /// Get one WorkerProfileSkill
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WorkerProfileSkill>> WorkerProfileSkill(
        [FromRoute()] WorkerProfileSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WorkerProfileSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one WorkerProfileSkill
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWorkerProfileSkill(
        [FromRoute()] WorkerProfileSkillWhereUniqueInput uniqueId,
        [FromQuery()] WorkerProfileSkillUpdateInput workerProfileSkillUpdateDto
    )
    {
        try
        {
            await _service.UpdateWorkerProfileSkill(uniqueId, workerProfileSkillUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
