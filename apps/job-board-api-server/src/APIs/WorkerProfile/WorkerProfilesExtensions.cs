using JobBoardApi.APIs.Dtos;
using JobBoardApi.Infrastructure.Models;

namespace JobBoardApi.APIs.Extensions;

public static class WorkerProfilesExtensions
{
    public static WorkerProfile ToDto(this WorkerProfileDbModel model)
    {
        return new WorkerProfile
        {
            Age = model.Age,
            Applications = model.Applications?.Select(x => x.Id).ToList(),
            Availability = model.Availability,
            ContactEmail = model.ContactEmail,
            ContactPhone = model.ContactPhone,
            CreatedAt = model.CreatedAt,
            Gender = model.Gender,
            Id = model.Id,
            Name = model.Name,
            SalaryExpectation = model.SalaryExpectation,
            SalaryMax = model.SalaryMax,
            SalaryMin = model.SalaryMin,
            UpdatedAt = model.UpdatedAt,
            User = model.UserId,
            WillingnessToWorkAbroad = model.WillingnessToWorkAbroad,
        };
    }

    public static WorkerProfileDbModel ToModel(
        this WorkerProfileUpdateInput updateDto,
        WorkerProfileWhereUniqueInput uniqueId
    )
    {
        var workerProfile = new WorkerProfileDbModel
        {
            Id = uniqueId.Id,
            Age = updateDto.Age,
            Availability = updateDto.Availability,
            ContactEmail = updateDto.ContactEmail,
            ContactPhone = updateDto.ContactPhone,
            Gender = updateDto.Gender,
            Name = updateDto.Name,
            SalaryExpectation = updateDto.SalaryExpectation,
            SalaryMax = updateDto.SalaryMax,
            SalaryMin = updateDto.SalaryMin,
            WillingnessToWorkAbroad = updateDto.WillingnessToWorkAbroad
        };

        if (updateDto.CreatedAt != null)
        {
            workerProfile.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            workerProfile.UpdatedAt = updateDto.UpdatedAt.Value;
        }
        if (updateDto.User != null)
        {
            workerProfile.UserId = updateDto.User;
        }

        return workerProfile;
    }
}
