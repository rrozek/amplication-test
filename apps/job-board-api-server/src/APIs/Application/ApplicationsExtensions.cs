using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class ApplicationsExtensions
{
    public static Application ToDto(this ApplicationDbModel model)
    {
        return new Application
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            JobPosting = model.JobPostingId,
            Status = model.Status,
            UpdatedAt = model.UpdatedAt,
            WorkerProfile = model.WorkerProfileId,
        };
    }

    public static ApplicationDbModel ToModel(
        this ApplicationUpdateInput updateDto,
        ApplicationWhereUniqueInput uniqueId
    )
    {
        var application = new ApplicationDbModel { Id = uniqueId.Id, Status = updateDto.Status };

        if (updateDto.CreatedAt != null)
        {
            application.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.JobPosting != null)
        {
            application.JobPostingId = updateDto.JobPosting;
        }
        if (updateDto.UpdatedAt != null)
        {
            application.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.WorkerProfile != null)
        {
            application.WorkerProfileId = updateDto.WorkerProfile;
        }

        return application;
    }
}
