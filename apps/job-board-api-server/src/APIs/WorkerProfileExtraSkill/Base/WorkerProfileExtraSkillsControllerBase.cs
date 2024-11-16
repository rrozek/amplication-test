using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WorkerProfileExtraSkillsControllerBase : ControllerBase
{
    protected readonly IWorkerProfileExtraSkillsService _service;

    public WorkerProfileExtraSkillsControllerBase(IWorkerProfileExtraSkillsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one WorkerProfileExtraSkill
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<WorkerProfileExtraSkill>> CreateWorkerProfileExtraSkill(
        WorkerProfileExtraSkillCreateInput input
    )
    {
        var workerProfileExtraSkill = await _service.CreateWorkerProfileExtraSkill(input);

        return CreatedAtAction(
            nameof(WorkerProfileExtraSkill),
            new { id = workerProfileExtraSkill.Id },
            workerProfileExtraSkill
        );
    }

    /// <summary>
    /// Delete one WorkerProfileExtraSkill
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWorkerProfileExtraSkill(
        [FromRoute()] WorkerProfileExtraSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteWorkerProfileExtraSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many WorkerProfileExtraSkills
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<WorkerProfileExtraSkill>>> WorkerProfileExtraSkills(
        [FromQuery()] WorkerProfileExtraSkillFindManyArgs filter
    )
    {
        return Ok(await _service.WorkerProfileExtraSkills(filter));
    }

    /// <summary>
    /// Meta data about WorkerProfileExtraSkill records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WorkerProfileExtraSkillsMeta(
        [FromQuery()] WorkerProfileExtraSkillFindManyArgs filter
    )
    {
        return Ok(await _service.WorkerProfileExtraSkillsMeta(filter));
    }

    /// <summary>
    /// Get one WorkerProfileExtraSkill
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<WorkerProfileExtraSkill>> WorkerProfileExtraSkill(
        [FromRoute()] WorkerProfileExtraSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.WorkerProfileExtraSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one WorkerProfileExtraSkill
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWorkerProfileExtraSkill(
        [FromRoute()] WorkerProfileExtraSkillWhereUniqueInput uniqueId,
        [FromQuery()] WorkerProfileExtraSkillUpdateInput workerProfileExtraSkillUpdateDto
    )
    {
        try
        {
            await _service.UpdateWorkerProfileExtraSkill(
                uniqueId,
                workerProfileExtraSkillUpdateDto
            );
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
