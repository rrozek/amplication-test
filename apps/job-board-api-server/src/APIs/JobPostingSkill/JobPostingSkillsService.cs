using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class JobPostingSkillsService : JobPostingSkillsServiceBase
{
    public JobPostingSkillsService(JobBoardApiDbContext context)
        : base(context) { }
}
