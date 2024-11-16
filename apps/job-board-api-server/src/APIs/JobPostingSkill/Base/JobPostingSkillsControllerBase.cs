using JobBoardApi.APIs;
using JobBoardApi.APIs.Common;
using JobBoardApi.APIs.Dtos;
using JobBoardApi.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class JobPostingSkillsControllerBase : ControllerBase
{
    protected readonly IJobPostingSkillsService _service;

    public JobPostingSkillsControllerBase(IJobPostingSkillsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one JobPostingSkill
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<JobPostingSkill>> CreateJobPostingSkill(
        JobPostingSkillCreateInput input
    )
    {
        var jobPostingSkill = await _service.CreateJobPostingSkill(input);

        return CreatedAtAction(
            nameof(JobPostingSkill),
            new { id = jobPostingSkill.Id },
            jobPostingSkill
        );
    }

    /// <summary>
    /// Delete one JobPostingSkill
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteJobPostingSkill(
        [FromRoute()] JobPostingSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteJobPostingSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many JobPostingSkills
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<JobPostingSkill>>> JobPostingSkills(
        [FromQuery()] JobPostingSkillFindManyArgs filter
    )
    {
        return Ok(await _service.JobPostingSkills(filter));
    }

    /// <summary>
    /// Meta data about JobPostingSkill records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> JobPostingSkillsMeta(
        [FromQuery()] JobPostingSkillFindManyArgs filter
    )
    {
        return Ok(await _service.JobPostingSkillsMeta(filter));
    }

    /// <summary>
    /// Get one JobPostingSkill
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<JobPostingSkill>> JobPostingSkill(
        [FromRoute()] JobPostingSkillWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.JobPostingSkill(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one JobPostingSkill
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateJobPostingSkill(
        [FromRoute()] JobPostingSkillWhereUniqueInput uniqueId,
        [FromQuery()] JobPostingSkillUpdateInput jobPostingSkillUpdateDto
    )
    {
        try
        {
            await _service.UpdateJobPostingSkill(uniqueId, jobPostingSkillUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
