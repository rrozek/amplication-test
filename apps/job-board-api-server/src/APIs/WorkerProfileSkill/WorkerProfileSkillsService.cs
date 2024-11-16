using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class WorkerProfileSkillsService : WorkerProfileSkillsServiceBase
{
    public WorkerProfileSkillsService(JobBoardApiDbContext context)
        : base(context) { }
}
