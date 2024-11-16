using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class ExtraSkillsService : ExtraSkillsServiceBase
{
    public ExtraSkillsService(JobBoardApiDbContext context)
        : base(context) { }
}
