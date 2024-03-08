using System.Linq.Expressions;
using System.Net;
using AutoMapper;
using LinqKit;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Entities;
using quickOS.Core.Models;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class ServiceProvidedService : IServiceProvidedService
{
    private readonly IServiceProvidedRepository _serviceProvidedRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServiceProvidedService(IServiceProvidedRepository serviceProvidedRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _serviceProvidedRepository = serviceProvidedRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ApiResponse<ServiceProvidedOutputModel>> CreateAsync(ServiceProvidedInputModel serviceInputModel)
    {
        var service = _mapper.Map<ServiceProvided>(serviceInputModel);

        await _serviceProvidedRepository.CreateAsync(service);
        await _unitOfWork.SaveChangesAsync();

        var createdService = _mapper.Map<ServiceProvidedOutputModel>(service);

        return ApiResponse<ServiceProvidedOutputModel>.Ok(createdService);
    }

    public async Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        var service = await _serviceProvidedRepository.GetByExternalIdAsync(externalId);

        if (service == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Serviço não encontrado");
        }

        _serviceProvidedRepository.Delete(service);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<PagedResult<ServiceProvidedOutputModel>>> GetAllAsync(ServiceProvidedQueryParams queryParams)
    {
        var filters = GetFilters(queryParams);
        var orderBy = GetOrderByField(queryParams);

        var services = await _serviceProvidedRepository.GetAllAsync(
            filters,
            orderBy,
            queryParams.OrderDirection,
            queryParams.CurrentPage,
            queryParams.PageSize);
        var servicesDTO = _mapper.Map<IEnumerable<ServiceProvidedOutputModel>>(services.Data);

        var result = new PagedResult<ServiceProvidedOutputModel>(
            services.CurrentPage,
            services.TotalPages,
            services.PageSize,
            services.TotalCount,
            servicesDTO);

        return ApiResponse<PagedResult<ServiceProvidedOutputModel>>.Ok(result);
    }

    public async Task<ApiResponse<ServiceProvidedOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        var service = await _serviceProvidedRepository.GetByExternalIdAsync(externalId);

        if (service == null)
        {
            return ApiResponse<ServiceProvidedOutputModel>.Error(HttpStatusCode.NotFound, "Serviço não encontrado");
        }

        var result = _mapper.Map<ServiceProvidedOutputModel>(service);

        return ApiResponse<ServiceProvidedOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<ServiceProvidedOutputModel>> UpdateAsync(Guid externalId, ServiceProvidedInputModel serviceInputModel)
    {
        var service = await _serviceProvidedRepository.GetByExternalIdAsync(externalId);

        if (service == null)
        {
            return ApiResponse<ServiceProvidedOutputModel>.Error(HttpStatusCode.NotFound, "Serviço não encontrado");
        }

        service.UpdateCode(serviceInputModel.Code);
        service.UpdateName(serviceInputModel.Name);
        service.UpdateDescription(serviceInputModel.Description);
        service.UpdatePrice(serviceInputModel.Price);
        service.UpdateIsActive(serviceInputModel.IsActive);
        await _unitOfWork.SaveChangesAsync();

        var result = _mapper.Map<ServiceProvidedOutputModel>(service);

        return ApiResponse<ServiceProvidedOutputModel>.Ok(result);
    }

    private ExpressionStarter<ServiceProvided>? GetFilters(ServiceProvidedQueryParams queryParams)
    {
        var predicate = PredicateBuilder.New<ServiceProvided>(true);

        if (queryParams.Code > 0)
        {
            predicate = predicate.And(x => x.Code == queryParams.Code);
        }
        if (!string.IsNullOrEmpty(queryParams.Name))
        {
            predicate = predicate.And(x => x.Name.Contains(queryParams.Name));
        }

        return predicate;
    }

    private Expression<Func<ServiceProvided, object>>? GetOrderByField(ServiceProvidedQueryParams queryParams)
    {
        return queryParams.OrderBy switch
        {
            nameof(ServiceProvided.Code) => x => x.Code,
            nameof(ServiceProvided.Name) => x => x.Name,
            _ => null,
        };
    }
}
