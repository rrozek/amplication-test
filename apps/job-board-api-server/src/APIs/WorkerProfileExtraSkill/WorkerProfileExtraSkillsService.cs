using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class WorkerProfileExtraSkillsService : WorkerProfileExtraSkillsServiceBase
{
    public WorkerProfileExtraSkillsService(JobBoardApiDbContext context)
        : base(context) { }
}
