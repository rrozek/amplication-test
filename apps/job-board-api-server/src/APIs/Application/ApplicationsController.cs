using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class ApplicationsController : ApplicationsControllerBase
{
    public ApplicationsController(IApplicationsService service)
        : base(service) { }
}
