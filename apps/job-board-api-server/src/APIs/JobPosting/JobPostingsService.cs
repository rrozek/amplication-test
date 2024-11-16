using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class JobPostingsService : JobPostingsServiceBase
{
    public JobPostingsService(JobBoardApiDbContext context)
        : base(context) { }
}
