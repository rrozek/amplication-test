using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class WorkerProfileExtraSkillsController : WorkerProfileExtraSkillsControllerBase
{
    public WorkerProfileExtraSkillsController(IWorkerProfileExtraSkillsService service)
        : base(service) { }
}
