using BC = BCrypt.Net.BCrypt;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Application.Mappings;

public static class UserMapping
{
    public static async Task<User> ToEntity(this UserInputModel inputModel, IRequestProvider requestProvider, ITenantRepository tenantRepository)
    {
        var tenant = await tenantRepository.GetByIdAsync(requestProvider.TenantId);

        return new User(
            inputModel.FullName,
            inputModel.Cellphone,
            inputModel.Email,
            BC.HashPassword(inputModel.Password),
            inputModel.Role,
            tenant,
            inputModel.IsActive,
            null);
    }

    public static UserOutputModel ToOutputModel(this User user)
    {
        return new UserOutputModel(
            user.ExternalId,
            user.FullName,
            user.Cellphone,
            user.Email,
            user.Role,
            user.IsActive);
    }

    public static IEnumerable<UserOutputModel> ToOutputModel(this IEnumerable<User> users)
    {
        return users.Select(user => user.ToOutputModel());
    }
}
