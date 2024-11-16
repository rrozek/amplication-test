using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class JobPostingSkillsController : JobPostingSkillsControllerBase
{
    public JobPostingSkillsController(IJobPostingSkillsService service)
        : base(service) { }
}
