using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface ICompanyService
{
    Task<ApiResponse<CompanyOutputModel>> GetCurrentAsync();
}
