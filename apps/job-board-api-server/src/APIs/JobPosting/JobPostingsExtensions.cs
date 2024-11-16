using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class JobPostingsExtensions
{
    public static JobPosting ToDto(this JobPostingDbModel model)
    {
        return new JobPosting
        {
            Agency = model.Agency,
            AnalyticsApplications = model.AnalyticsApplications,
            AnalyticsClicks = model.AnalyticsClicks,
            AnalyticsViews = model.AnalyticsViews,
            Applications = model.Applications?.Select(x => x.Id).ToList(),
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Location = model.Location,
            SalaryMax = model.SalaryMax,
            SalaryMin = model.SalaryMin,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static JobPostingDbModel ToModel(
        this JobPostingUpdateInput updateDto,
        JobPostingWhereUniqueInput uniqueId
    )
    {
        var jobPosting = new JobPostingDbModel
        {
            Id = uniqueId.Id,
            Agency = updateDto.Agency,
            AnalyticsApplications = updateDto.AnalyticsApplications,
            AnalyticsClicks = updateDto.AnalyticsClicks,
            AnalyticsViews = updateDto.AnalyticsViews,
            Location = updateDto.Location,
            SalaryMax = updateDto.SalaryMax,
            SalaryMin = updateDto.SalaryMin,
            Title = updateDto.Title
        };

        if (updateDto.CreatedAt != null)
        {
            jobPosting.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            jobPosting.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return jobPosting;
    }
}
