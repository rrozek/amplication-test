using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class SkillsController : SkillsControllerBase
{
    public SkillsController(ISkillsService service)
        : base(service) { }
}
