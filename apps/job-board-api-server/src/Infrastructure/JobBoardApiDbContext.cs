using JobBoardApi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace JobBoardApi.Infrastructure;

public class JobBoardApiDbContext : DbContext
{
    public JobBoardApiDbContext(DbContextOptions<JobBoardApiDbContext> options)
        : base(options) { }

    public DbSet<SkillDbModel> Skills { get; set; }

    public DbSet<ExtraSkillDbModel> ExtraSkills { get; set; }

    public DbSet<WorkerProfileDbModel> WorkerProfiles { get; set; }

    public DbSet<ApplicationDbModel> Applications { get; set; }

    public DbSet<JobPostingDbModel> JobPostings { get; set; }

    public DbSet<UserDbModel> Users { get; set; }

    public DbSet<WorkerProfileSkillDbModel> WorkerProfileSkills { get; set; }

    public DbSet<JobPostingSkillDbModel> JobPostingSkills { get; set; }

    public DbSet<JobPostingExtraSkillDbModel> JobPostingExtraSkills { get; set; }

    public DbSet<WorkerProfileExtraSkillDbModel> WorkerProfileExtraSkills { get; set; }
}
