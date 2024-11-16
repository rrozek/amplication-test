using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SkillsControllerBase : ControllerBase
{
    protected readonly ISkillsService _service;

    public SkillsControllerBase(ISkillsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Skill
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Skill>> CreateSkill(SkillCreateInput input)
    {
        var skill = await _service.CreateSkill(input);

        return CreatedAtAction(nameof(Skill), new { id = skill.Id }, skill);
    }

    /// <summary>
    /// Delete one Skill
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSkill([FromRoute()] SkillWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Skills
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Skill>>> Skills([FromQuery()] SkillFindManyArgs filter)
    {
        return Ok(await _service.Skills(filter));
    }

    /// <summary>
    /// Meta data about Skill records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SkillsMeta([FromQuery()] SkillFindManyArgs filter)
    {
        return Ok(await _service.SkillsMeta(filter));
    }

    /// <summary>
    /// Get one Skill
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Skill>> Skill([FromRoute()] SkillWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Skill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Skill
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSkill(
        [FromRoute()] SkillWhereUniqueInput uniqueId,
        [FromQuery()] SkillUpdateInput skillUpdateDto
    )
    {
        try
        {
            await _service.UpdateSkill(uniqueId, skillUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
