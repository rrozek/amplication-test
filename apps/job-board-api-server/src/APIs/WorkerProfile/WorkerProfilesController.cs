using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class WorkerProfilesController : WorkerProfilesControllerBase
{
    public WorkerProfilesController(IWorkerProfilesService service)
        : base(service) { }
}
