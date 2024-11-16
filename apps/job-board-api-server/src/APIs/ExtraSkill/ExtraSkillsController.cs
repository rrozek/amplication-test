using Microsoft.AspNetCore.Mvc;

namespace JobBoardApi.APIs;

[ApiController()]
public class ExtraSkillsController : ExtraSkillsControllerBase
{
    public ExtraSkillsController(IExtraSkillsService service)
        : base(service) { }
}
