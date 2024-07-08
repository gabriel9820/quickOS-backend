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

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ApiResponse<CustomerOutputModel>> CreateAsync(CustomerInputModel customerInputModel)
    {
        try
        {
            var customer = customerInputModel.ToEntity();

            await _customerRepository.CreateAsync(customer);
            await _unitOfWork.SaveChangesAsync();

            var createdCustomer = customer.ToOutputModel();

            return ApiResponse<CustomerOutputModel>.Ok(createdCustomer);
        }
        catch (Exception ex) when (ex.InnerException != null && ex.InnerException.Message.Contains("23505:"))
        {
            var field = GetFieldFromExceptionMessage(ex.InnerException.Message);
            return ApiResponse<CustomerOutputModel>.Error(HttpStatusCode.BadRequest, $"Já existe um cliente com o {field} informado");
        }
    }

    public async Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        var customer = await _customerRepository.GetByExternalIdAsync(externalId);

        if (customer == null)
        {
            return ApiResponse.Error(HttpStatusCode.NotFound, "Cliente não encontrado");
        }

        _customerRepository.Delete(customer);
        await _unitOfWork.SaveChangesAsync();

        return ApiResponse.Ok();
    }

    public async Task<ApiResponse<IEnumerable<CustomerOutputModel>>> FillAutocompleteAsync()
    {
        var customers = await _customerRepository.FillAutocompleteAsync();
        var customersDTO = customers.ToOutputModel();

        return ApiResponse<IEnumerable<CustomerOutputModel>>.Ok(customersDTO);
    }

    public async Task<ApiResponse<PagedResult<CustomerOutputModel>>> GetAllAsync(CustomerQueryParams queryParams)
    {
        var filters = GetFilters(queryParams);
        var orderBy = GetOrderByField(queryParams);

        var customers = await _customerRepository.GetAllAsync(
            filters,
            orderBy,
            queryParams.OrderDirection,
            queryParams.CurrentPage,
            queryParams.PageSize);

        var result = new PagedResult<CustomerOutputModel>(
            customers.CurrentPage,
            customers.TotalPages,
            customers.PageSize,
            customers.TotalCount,
            customers.Data.ToOutputModel());

        return ApiResponse<PagedResult<CustomerOutputModel>>.Ok(result);
    }

    public async Task<ApiResponse<CustomerOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        var customer = await _customerRepository.GetByExternalIdAsync(externalId);

        if (customer == null)
        {
            return ApiResponse<CustomerOutputModel>.Error(HttpStatusCode.NotFound, "Cliente não encontrado");
        }

        var result = customer.ToOutputModel();

        return ApiResponse<CustomerOutputModel>.Ok(result);
    }

    public async Task<ApiResponse<int>> GetNextCode()
    {
        var nextCode = await _customerRepository.GetNextCode();

        return ApiResponse<int>.Ok(nextCode);
    }

    public async Task<ApiResponse<CustomerOutputModel>> UpdateAsync(Guid externalId, CustomerInputModel customerInputModel)
    {
        try
        {
            var customer = await _customerRepository.GetByExternalIdAsync(externalId);

            if (customer == null)
            {
                return ApiResponse<CustomerOutputModel>.Error(HttpStatusCode.NotFound, "Cliente não encontrado");
            }

            var address = customerInputModel.Address?.ToValueObject();

            customer.UpdateCode(customerInputModel.Code);
            customer.UpdateType(customerInputModel.Type);
            customer.UpdateDocument(customerInputModel.Document);
            customer.UpdateFullName(customerInputModel.FullName);
            customer.UpdateCellphone(customerInputModel.Cellphone);
            customer.UpdateEmail(customerInputModel.Email);
            customer.UpdateAddress(address);
            customer.UpdateIsActive(customerInputModel.IsActive);
            await _unitOfWork.SaveChangesAsync();

            var result = customer.ToOutputModel();

            return ApiResponse<CustomerOutputModel>.Ok(result);
        }
        catch (Exception ex) when (ex.InnerException != null && ex.InnerException.Message.Contains("23505:"))
        {
            var field = GetFieldFromExceptionMessage(ex.InnerException.Message);
            return ApiResponse<CustomerOutputModel>.Error(HttpStatusCode.BadRequest, $"Já existe um cliente com o {field} informado");
        }
    }

    private ExpressionStarter<Customer>? GetFilters(CustomerQueryParams queryParams)
    {
        var predicate = PredicateBuilder.New<Customer>(true);

        if (queryParams.Code.HasValue)
        {
            predicate = predicate.And(x => x.Code == queryParams.Code);
        }
        if (queryParams.Types?.Length > 0)
        {
            predicate = predicate.And(x => queryParams.Types.Contains(x.Type));
        }
        if (!string.IsNullOrEmpty(queryParams.Document))
        {
            predicate = predicate.And(x => x.Document.Contains(queryParams.Document));
        }
        if (!string.IsNullOrEmpty(queryParams.FullName))
        {
            predicate = predicate.And(x => x.FullName.Contains(queryParams.FullName));
        }
        if (!string.IsNullOrEmpty(queryParams.Email))
        {
            predicate = predicate.And(x => x.Email.Contains(queryParams.Email));
        }
        if (queryParams.IsActive.HasValue)
        {
            predicate = predicate.And(x => x.IsActive == queryParams.IsActive);
        }

        return predicate;
    }

    private Expression<Func<Customer, object>>? GetOrderByField(CustomerQueryParams queryParams)
    {
        return queryParams.OrderBy switch
        {
            "code" => x => x.Code,
            "type" => x => x.Type,
            "document" => x => x.Document,
            "fullName" => x => x.FullName,
            "isActive" => x => x.IsActive,
            _ => null,
        };
    }

    private string GetFieldFromExceptionMessage(string message)
    {
        var fieldMappings = new Dictionary<string, string>
        {
            { "Document", "Documento" },
            { "Code", "Código" },
            { "Cellphone", "Celular" },
            { "Email", "E-mail" }
        };

        foreach (var mapping in fieldMappings)
        {
            if (message.Contains(mapping.Key))
            {
                return mapping.Value;
            }
        }

        return "Campo desconhecido";
    }
}
