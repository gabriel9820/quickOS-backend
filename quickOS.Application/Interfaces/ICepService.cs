using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface ICepService
{
    Task<ApiResponse<AddressOutputModel>> GetAddressByCepAsync(string cep);
}
