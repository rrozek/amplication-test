using JobBoardApi.Infrastructure;

namespace JobBoardApi.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(JobBoardApiDbContext context)
        : base(context) { }
}
