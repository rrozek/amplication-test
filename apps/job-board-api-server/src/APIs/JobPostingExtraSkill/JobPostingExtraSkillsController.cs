using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class JobPostingExtraSkillsController : JobPostingExtraSkillsControllerBase
{
    public JobPostingExtraSkillsController(IJobPostingExtraSkillsService service)
        : base(service) { }
}
