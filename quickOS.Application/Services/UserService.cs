using System.Linq.Expressions;
using System.Net;
using LinqKit;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Application.Mappings;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITenantRepository _tenantRepository;
    private readonly IRequestProvider _requestProvider;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, ITenantRepository tenantRepository, IRequestProvider requestProvider, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _tenantRepository = tenantRepository;
        _requestProvider = requestProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<UserOutputModel>> CreateAsync(UserCreateInputModel userInputModel)
    {
        var user = await userInputModel.ToEntity(_requestProvider, _tenantRepository);

        await _userRepository.CreateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        var createdUser = user.ToOutputModel();

        return ApiResponse<UserOutputModel>.Ok(createdUser);
    }

    public async Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        var user = await _userRepository.GetByExternalIdAsync(externalId);

        if (user == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Usuário não encontrado");
        }

        if (user.Id == _requestProvider.UserId)
        {
            return ApiResponse.Error(HttpStatusCode.BadRequest, "Não é possível excluir seu próprio usuário");
        }

        _userRepository.Delete(user);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<PagedResult<UserOutputModel>>> GetAllAsync(UserQueryParams queryParams)
    {
        var filters = GetFilters(queryParams);
        var orderBy = GetOrderByField(queryParams);

        var users = await _userRepository.GetAllAsync(
            filters,
            orderBy,
            queryParams.OrderDirection,
            queryParams.CurrentPage,
            queryParams.PageSize);

        var result = new PagedResult<UserOutputModel>(
            users.CurrentPage,
            users.TotalPages,
            users.PageSize,
            users.TotalCount,
            users.Data.ToOutputModel());

        return ApiResponse<PagedResult<UserOutputModel>>.Ok(result);
    }

    public async Task<ApiResponse<UserOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        var user = await _userRepository.GetByExternalIdAsync(externalId);

        if (user == null)
        {
            return ApiResponse<UserOutputModel>.Error(HttpStatusCode.NotFound, "Usuário não encontrado");
        }

        var result = user.ToOutputModel();

        return ApiResponse<UserOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<UserOutputModel>> UpdateAsync(Guid externalId, UserInputModel userInputModel)
    {
        var user = await _userRepository.GetByExternalIdAsync(externalId);

        if (user == null)
        {
            return ApiResponse<UserOutputModel>.Error(HttpStatusCode.NotFound, "Usuário não encontrado");
        }

        if (user.Id == _requestProvider.UserId)
        {
            return ApiResponse<UserOutputModel>.Error(HttpStatusCode.BadRequest, "Não é possível alterar seu próprio usuário");
        }

        user.UpdateFullName(userInputModel.FullName);
        user.UpdateCellphone(userInputModel.Cellphone);
        user.UpdateRole(userInputModel.Role);
        user.UpdateIsActive(userInputModel.IsActive);

        await _unitOfWork.SaveChangesAsync();

        var result = user.ToOutputModel();

        return ApiResponse<UserOutputModel>.Ok(result);
    }

    private ExpressionStarter<User>? GetFilters(UserQueryParams queryParams)
    {
        var predicate = PredicateBuilder.New<User>(true);

        if (!string.IsNullOrEmpty(queryParams.FullName))
        {
            predicate = predicate.And(x => x.FullName.Contains(queryParams.FullName));
        }
        if (!string.IsNullOrEmpty(queryParams.Cellphone))
        {
            predicate = predicate.And(x => x.Cellphone == queryParams.Cellphone);
        }
        if (!string.IsNullOrEmpty(queryParams.Email))
        {
            predicate = predicate.And(x => x.Email == queryParams.Email);
        }
        if (queryParams.Role.HasValue)
        {
            predicate = predicate.And(x => x.Role == queryParams.Role);
        }
        if (queryParams.IsActive.HasValue)
        {
            predicate = predicate.And(x => x.IsActive == queryParams.IsActive);
        }

        return predicate;
    }

    private Expression<Func<User, object>>? GetOrderByField(UserQueryParams queryParams)
    {
        return queryParams.OrderBy switch
        {
            "fullName" => x => x.FullName,
            "email" => x => x.Email,
            "role" => x => x.Role,
            "isActive" => x => x.IsActive,
            _ => null,
        };
    }
}
