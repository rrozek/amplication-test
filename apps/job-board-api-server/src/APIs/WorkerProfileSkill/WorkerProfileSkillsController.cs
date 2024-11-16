using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class WorkerProfileSkillsController : WorkerProfileSkillsControllerBase
{
    public WorkerProfileSkillsController(IWorkerProfileSkillsService service)
        : base(service) { }
}
