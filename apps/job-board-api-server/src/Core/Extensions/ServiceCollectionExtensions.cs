using JobBoardApi.APIs;

namespace JobBoardApi;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationsService, ApplicationsService>();
        services.AddScoped<IExtraSkillsService, ExtraSkillsService>();
        services.AddScoped<IJobPostingsService, JobPostingsService>();
        services.AddScoped<IJobPostingExtraSkillsService, JobPostingExtraSkillsService>();
        services.AddScoped<IJobPostingSkillsService, JobPostingSkillsService>();
        services.AddScoped<ISkillsService, SkillsService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IWorkerProfilesService, WorkerProfilesService>();
        services.AddScoped<IWorkerProfileExtraSkillsService, WorkerProfileExtraSkillsService>();
        services.AddScoped<IWorkerProfileSkillsService, WorkerProfileSkillsService>();
    }
}
