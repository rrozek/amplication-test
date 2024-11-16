using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class JobPostingExtraSkillsService : JobPostingExtraSkillsServiceBase
{
    public JobPostingExtraSkillsService(JobBoardApiDbContext context)
        : base(context) { }
}
