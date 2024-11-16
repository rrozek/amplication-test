using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class SkillsService : SkillsServiceBase
{
    public SkillsService(JobBoardApiDbContext context)
        : base(context) { }
}
