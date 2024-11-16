using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class ApplicationsService : ApplicationsServiceBase
{
    public ApplicationsService(JobBoardApiDbContext context)
        : base(context) { }
}
