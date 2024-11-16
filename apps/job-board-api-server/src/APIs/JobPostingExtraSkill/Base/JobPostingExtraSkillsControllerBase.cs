using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class JobPostingExtraSkillsControllerBase : ControllerBase
{
    protected readonly IJobPostingExtraSkillsService _service;

    public JobPostingExtraSkillsControllerBase(IJobPostingExtraSkillsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one JobPostingExtraSkill
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<JobPostingExtraSkill>> CreateJobPostingExtraSkill(
        JobPostingExtraSkillCreateInput input
    )
    {
        var jobPostingExtraSkill = await _service.CreateJobPostingExtraSkill(input);

        return CreatedAtAction(
            nameof(JobPostingExtraSkill),
            new { id = jobPostingExtraSkill.Id },
            jobPostingExtraSkill
        );
    }

    /// <summary>
    /// Delete one JobPostingExtraSkill
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteJobPostingExtraSkill(
        [FromRoute()] JobPostingExtraSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteJobPostingExtraSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many JobPostingExtraSkills
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<JobPostingExtraSkill>>> JobPostingExtraSkills(
        [FromQuery()] JobPostingExtraSkillFindManyArgs filter
    )
    {
        return Ok(await _service.JobPostingExtraSkills(filter));
    }

    /// <summary>
    /// Meta data about JobPostingExtraSkill records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> JobPostingExtraSkillsMeta(
        [FromQuery()] JobPostingExtraSkillFindManyArgs filter
    )
    {
        return Ok(await _service.JobPostingExtraSkillsMeta(filter));
    }

    /// <summary>
    /// Get one JobPostingExtraSkill
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<JobPostingExtraSkill>> JobPostingExtraSkill(
        [FromRoute()] JobPostingExtraSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.JobPostingExtraSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one JobPostingExtraSkill
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateJobPostingExtraSkill(
        [FromRoute()] JobPostingExtraSkillWhereUniqueInput uniqueId,
        [FromQuery()] JobPostingExtraSkillUpdateInput jobPostingExtraSkillUpdateDto
    )
    {
        try
        {
            await _service.UpdateJobPostingExtraSkill(uniqueId, jobPostingExtraSkillUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
