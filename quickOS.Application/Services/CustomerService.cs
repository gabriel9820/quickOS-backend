using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;
using quickOS.Core.Models;

namespace quickOS.Application.Services;

public class CustomerService : ICustomerService
{
    public Task<ApiResponse<CustomerOutputModel>> CreateAsync(CustomerInputModel customerInputModel)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse> DeleteAsync(Guid externalId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<PagedResult<CustomerOutputModel>>> GetAllAsync(CustomerQueryParams queryParams)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<CustomerOutputModel>> GetByExternalIdAsync(Guid externalId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<int>> GetNextCode()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<CustomerOutputModel>> UpdateAsync(Guid externalId, CustomerInputModel customerInputModel)
    {
        throw new NotImplementedException();
    }
}
