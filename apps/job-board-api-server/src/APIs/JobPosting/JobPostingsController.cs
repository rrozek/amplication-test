using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class JobPostingsController : JobPostingsControllerBase
{
    public JobPostingsController(IJobPostingsService service)
        : base(service) { }
}
