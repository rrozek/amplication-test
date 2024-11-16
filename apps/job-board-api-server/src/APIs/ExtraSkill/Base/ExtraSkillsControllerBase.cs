using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ExtraSkillsControllerBase : ControllerBase
{
    protected readonly IExtraSkillsService _service;

    public ExtraSkillsControllerBase(IExtraSkillsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Extra Skill
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ExtraSkill>> CreateExtraSkill(ExtraSkillCreateInput input)
    {
        var extraSkill = await _service.CreateExtraSkill(input);

        return CreatedAtAction(nameof(ExtraSkill), new { id = extraSkill.Id }, extraSkill);
    }

    /// <summary>
    /// Delete one Extra Skill
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteExtraSkill(
        [FromRoute()] ExtraSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteExtraSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Extra Skills
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ExtraSkill>>> ExtraSkills(
        [FromQuery()] ExtraSkillFindManyArgs filter
    )
    {
        return Ok(await _service.ExtraSkills(filter));
    }

    /// <summary>
    /// Meta data about Extra Skill records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ExtraSkillsMeta(
        [FromQuery()] ExtraSkillFindManyArgs filter
    )
    {
        return Ok(await _service.ExtraSkillsMeta(filter));
    }

    /// <summary>
    /// Get one Extra Skill
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ExtraSkill>> ExtraSkill(
        [FromRoute()] ExtraSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ExtraSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Extra Skill
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateExtraSkill(
        [FromRoute()] ExtraSkillWhereUniqueInput uniqueId,
        [FromQuery()] ExtraSkillUpdateInput extraSkillUpdateDto
    )
    {
        try
        {
            await _service.UpdateExtraSkill(uniqueId, extraSkillUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
