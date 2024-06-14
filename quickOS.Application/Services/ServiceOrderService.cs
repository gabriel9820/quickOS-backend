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

public class ServiceOrderService : IServiceOrderService
{
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfMeasurementRepository _unitOfMeasurementRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ServiceOrderService(
        IServiceOrderRepository serviceOrderRepository,
        ICustomerRepository customerRepository,
        IUserRepository userRepository,
        IUnitOfMeasurementRepository unitOfMeasurementRepository,
        IUnitOfWork unitOfWork)
    {
        _serviceOrderRepository = serviceOrderRepository;
        _customerRepository = customerRepository;
        _userRepository = userRepository;
        _unitOfMeasurementRepository = unitOfMeasurementRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<ServiceOrderOutputModel>> CreateAsync(ServiceOrderInputModel serviceOrderInputModel)
    {
        var serviceOrder = await serviceOrderInputModel.ToEntity(_customerRepository, _userRepository);

        await _serviceOrderRepository.CreateAsync(serviceOrder);
        await _unitOfWork.SaveChangesAsync();

        var createdServiceOrder = serviceOrder.ToOutputModel();

        return ApiResponse<ServiceOrderOutputModel>.Ok(createdServiceOrder);
    }

    public async Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        var serviceOrder = await _serviceOrderRepository.GetByExternalIdAsync(externalId);

        if (serviceOrder == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Cliente não encontrado");
        }

        _serviceOrderRepository.Delete(serviceOrder);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<PagedResult<ServiceOrderOutputModel>>> GetAllAsync(ServiceOrderQueryParams queryParams)
    {
        var filters = GetFilters(queryParams);
        var orderBy = GetOrderByField(queryParams);

        var serviceOrders = await _serviceOrderRepository.GetAllAsync(
            filters,
            orderBy,
            queryParams.OrderDirection,
            queryParams.CurrentPage,
            queryParams.PageSize);

        var result = new PagedResult<ServiceOrderOutputModel>(
            serviceOrders.CurrentPage,
            serviceOrders.TotalPages,
            serviceOrders.PageSize,
            serviceOrders.TotalCount,
            serviceOrders.Data.ToOutputModel());

        return ApiResponse<PagedResult<ServiceOrderOutputModel>>.Ok(result);
    }

    public async Task<ApiResponse<ServiceOrderOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        var serviceOrder = await _serviceOrderRepository.GetByExternalIdAsync(externalId);

        if (serviceOrder == null)
        {
            return ApiResponse<ServiceOrderOutputModel>.Error(HttpStatusCode.NotFound, "Cliente não encontrado");
        }

        var result = serviceOrder.ToOutputModel();

        return ApiResponse<ServiceOrderOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<int>> GetNextNumber()
    {
        var nextNumber = await _serviceOrderRepository.GetNextNumber();

        return ApiResponse<int>.Ok(nextNumber);
    }

    public async Task<ApiResponse<ServiceOrderOutputModel>> UpdateAsync(Guid externalId, ServiceOrderInputModel serviceOrderInputModel)
    {
        var serviceOrder = await _serviceOrderRepository.GetByExternalIdAsync(externalId);

        if (serviceOrder == null)
        {
            return ApiResponse<ServiceOrderOutputModel>.Error(HttpStatusCode.NotFound, "Cliente não encontrado");
        }

        var technician = await _userRepository.GetByExternalIdAsync(serviceOrderInputModel.Technician);

        serviceOrder.UpdateStatus(serviceOrderInputModel.Status);
        serviceOrder.UpdateEquipmentDescription(serviceOrderInputModel.EquipmentDescription);
        serviceOrder.UpdateProblemDescription(serviceOrderInputModel.ProblemDescription);
        serviceOrder.UpdateTechnicalReport(serviceOrderInputModel.TechnicalReport);
        serviceOrder.UpdateTechnician(technician);
        serviceOrder.CalculateTotalPrice();
        await _unitOfWork.SaveChangesAsync();

        var result = serviceOrder.ToOutputModel();

        return ApiResponse<ServiceOrderOutputModel>.Ok(result);
    }

    private ExpressionStarter<ServiceOrder>? GetFilters(ServiceOrderQueryParams queryParams)
    {
        var predicate = PredicateBuilder.New<ServiceOrder>(true);

        if (queryParams.Number.HasValue)
        {
            predicate = predicate.And(x => x.Number == queryParams.Number);
        }
        if (queryParams.Status?.Length > 0)
        {
            predicate = predicate.And(x => queryParams.Status.Contains(x.Status));
        }
        if (queryParams.Date.HasValue)
        {
            predicate = predicate.And(x => x.Date == queryParams.Date);
        }
        if (queryParams.Customer.HasValue)
        {
            predicate = predicate.And(x => x.Customer.ExternalId == queryParams.Customer);
        }
        if (queryParams.Technician.HasValue)
        {
            predicate = predicate.And(x => x.Technician.ExternalId == queryParams.Technician);
        }

        return predicate;
    }

    private Expression<Func<ServiceOrder, object>>? GetOrderByField(ServiceOrderQueryParams queryParams)
    {
        return queryParams.OrderBy switch
        {
            "number" => x => x.Number,
            "date" => x => x.Date,
            "customer" => x => x.Customer,
            "technician" => x => x.Technician,
            "status" => x => x.Status,
            _ => null,
        };
    }
}
