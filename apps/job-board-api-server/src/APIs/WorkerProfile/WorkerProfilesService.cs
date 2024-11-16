using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class WorkerProfilesService : WorkerProfilesServiceBase
{
    public WorkerProfilesService(JobBoardApiDbContext context)
        : base(context) { }
}
