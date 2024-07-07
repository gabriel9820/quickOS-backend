using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface IDashboardService
{
    Task<ApiResponse<DashboardOutputModel>> GetDashboardAsync(DashboardQueryParams queryParams);
}
