using System.Linq.Expressions;
using System.Net;
using LinqKit;
using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Application.Mappings;
using quickOS.Core.Entities;
using quickOS.Core.Enums;
using quickOS.Core.Models;
using quickOS.Core.Reports;
using quickOS.Core.Repositories;

namespace quickOS.Application.Services;

public class ServiceOrderService : IServiceOrderService
{
    private readonly IServiceOrderRepository _serviceOrderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IUserRepository _userRepository;
    private readonly IServiceProvidedRepository _serviceProvidedRepository;
    private readonly IProductRepository _productRepository;
    private readonly IAccountReceivableRepository _accountReceivableRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceOrderReport _serviceOrderReport;

    public ServiceOrderService(
        IServiceOrderRepository serviceOrderRepository,
        ICustomerRepository customerRepository,
        IUserRepository userRepository,
        IServiceProvidedRepository serviceProvidedRepository,
        IProductRepository productRepository,
        IAccountReceivableRepository accountReceivableRepository,
        IUnitOfWork unitOfWork,
        IServiceOrderReport serviceOrderReport)
    {
        _serviceOrderRepository = serviceOrderRepository;
        _customerRepository = customerRepository;
        _userRepository = userRepository;
        _serviceProvidedRepository = serviceProvidedRepository;
        _productRepository = productRepository;
        _accountReceivableRepository = accountReceivableRepository;
        _unitOfWork = unitOfWork;
        _serviceOrderReport = serviceOrderReport;
    }

    public async Task<ApiResponse<ServiceOrderOutputModel>> CreateAsync(ServiceOrderInputModel serviceOrderInputModel)
    {
        var serviceOrder = await serviceOrderInputModel.ToEntity(_customerRepository, _userRepository, _serviceProvidedRepository, _productRepository);

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
            return ApiResponse.Error(HttpStatusCode.NotFound, "Ordem de serviço não encontrada");
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
            return ApiResponse<ServiceOrderOutputModel>.Error(HttpStatusCode.NotFound, "Ordem de serviço não encontrada");
        }

        var result = serviceOrder.ToOutputModel();

        return ApiResponse<ServiceOrderOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<int>> GetNextNumber()
    {
        var nextNumber = await _serviceOrderRepository.GetNextNumber();

        return ApiResponse<int>.Ok(nextNumber);
    }

    public async Task<ApiResponse<byte[]>> IndividualReportAsync(Guid externalId)
    {
        var serviceOrder = await _serviceOrderRepository.GetByExternalIdAsync(externalId);

        if (serviceOrder == null)
        {
            return ApiResponse<byte[]>.Error(HttpStatusCode.NotFound, "Ordem de serviço não encontrada");
        }

        var report = _serviceOrderReport.GenerateIndividual(serviceOrder);

        return ApiResponse<byte[]>.Ok(report);
    }

    public async Task<ApiResponse> InvoiceAsync(Guid externalId, ServiceOrderInvoiceInputModel inputModel)
    {
        var serviceOrder = await _serviceOrderRepository.GetByExternalIdAsync(externalId);

        if (serviceOrder == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Ordem de serviço não encontrada");
        }

        if (serviceOrder.Status == ServiceOrderStatus.Invoiced)
        {
            return ApiResponse.Error(HttpStatusCode.BadRequest, "Ordem de serviço já faturada");
        }

        if (serviceOrder.TotalPrice <= 0)
        {
            return ApiResponse.Error(HttpStatusCode.BadRequest, "Ordem de serviço não possui valor, informe os serviços e/ou produtos no lançamento");
        }

        var dueDate = inputModel.PaymentType == PaymentType.InstallmentPayment ? inputModel.DueDate!.Value : inputModel.Now;
        DateOnly? paymentDate = inputModel.PaymentType == PaymentType.CashPayment ? inputModel.Now : null;
        var isPaidOut = inputModel.PaymentType == PaymentType.CashPayment;

        var accountReceivable = new AccountReceivable(
            inputModel.Now,
            dueDate,
            paymentDate,
            serviceOrder.Number.ToString(),
            $"Recebimento referente a OS: {serviceOrder.Number} de {serviceOrder.Customer.FullName}",
            serviceOrder.TotalPrice,
            isPaidOut,
            serviceOrder.Customer,
            serviceOrder);
        serviceOrder.Invoice();

        await _accountReceivableRepository.CreateAsync(accountReceivable);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<ServiceOrderOutputModel>> UpdateAsync(Guid externalId, ServiceOrderInputModel serviceOrderInputModel)
    {
        var serviceOrder = await _serviceOrderRepository.GetByExternalIdAsync(externalId);

        if (serviceOrder == null)
        {
            return ApiResponse<ServiceOrderOutputModel>.Error(HttpStatusCode.NotFound, "Ordem de serviço não encontrada");
        }

        if (serviceOrder.Status == ServiceOrderStatus.Invoiced)
        {
            return ApiResponse<ServiceOrderOutputModel>.Error(HttpStatusCode.BadRequest, "Ordem de serviço faturada, não é permitido a alteração");
        }

        var technician = await _userRepository.GetByExternalIdAsync(serviceOrderInputModel.Technician);

        serviceOrder.UpdateStatus(serviceOrderInputModel.Status);
        serviceOrder.UpdateEquipmentDescription(serviceOrderInputModel.EquipmentDescription);
        serviceOrder.UpdateProblemDescription(serviceOrderInputModel.ProblemDescription);
        serviceOrder.UpdateTechnicalReport(serviceOrderInputModel.TechnicalReport);
        serviceOrder.UpdateTechnician(technician);

        await SetServices(serviceOrder, serviceOrderInputModel);
        await SetProducts(serviceOrder, serviceOrderInputModel);

        serviceOrder.CalculateTotalPrice();

        await _unitOfWork.SaveChangesAsync();

        var result = serviceOrder.ToOutputModel();

        return ApiResponse<ServiceOrderOutputModel>.Ok(result);
    }

    private async Task SetServices(ServiceOrder serviceOrder, ServiceOrderInputModel serviceOrderInputModel)
    {
        var servicesInputModelIds = serviceOrderInputModel.Services.Select(s => s.ExternalId).ToList();
        var servicesToRemove = serviceOrder.Services.Where(s => !servicesInputModelIds.Contains(s.ExternalId)).ToList();
        foreach (var service in servicesToRemove)
        {
            serviceOrder.RemoveService(service);
        }

        foreach (var serviceInputModel in serviceOrderInputModel.Services)
        {
            if (serviceInputModel.ExternalId.HasValue)
            {
                var service = serviceOrder.Services.FirstOrDefault(x => x.ExternalId == serviceInputModel.ExternalId);

                if (service != null)
                {
                    var serviceProvided = await _serviceProvidedRepository.GetByExternalIdAsync(serviceInputModel.Service);

                    service.UpdateItem(serviceInputModel.Item);
                    service.UpdateService(serviceProvided);
                    service.UpdateQuantity(serviceInputModel.Quantity);
                    service.UpdatePrice(serviceInputModel.Price);
                    service.CalculateTotalPrice();
                }
            }
            else
            {
                var service = await serviceInputModel.ToEntity(_serviceProvidedRepository);
                serviceOrder.AddService(service);
            }
        }
    }

    private async Task SetProducts(ServiceOrder serviceOrder, ServiceOrderInputModel serviceOrderInputModel)
    {
        var productsInputModelIds = serviceOrderInputModel.Products.Select(s => s.ExternalId).ToList();
        var productsToRemove = serviceOrder.Products.Where(s => !productsInputModelIds.Contains(s.ExternalId)).ToList();
        foreach (var product in productsToRemove)
        {
            serviceOrder.RemoveProduct(product);
        }

        foreach (var productInputModel in serviceOrderInputModel.Products)
        {
            if (productInputModel.ExternalId.HasValue)
            {
                var product = serviceOrder.Products.FirstOrDefault(x => x.ExternalId == productInputModel.ExternalId);

                if (product != null)
                {
                    var productEntity = await _productRepository.GetByExternalIdAsync(productInputModel.Product);

                    product.UpdateItem(productInputModel.Item);
                    product.UpdateProduct(productEntity);
                    product.UpdateQuantity(productInputModel.Quantity);
                    product.UpdatePrice(productInputModel.Price);
                    product.CalculateTotalPrice();
                }
            }
            else
            {
                var product = await productInputModel.ToEntity(_productRepository);
                serviceOrder.AddProduct(product);
            }
        }
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
            predicate = predicate.And(x => DateOnly.FromDateTime(x.Date) == DateOnly.FromDateTime(queryParams.Date.Value));
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
