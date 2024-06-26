using System.Text.Json;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Application.Interfaces;

namespace quickOS.Infra.Services;

public class CepService : ICepService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CepService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ApiResponse<AddressOutputModel>> GetAddressByCepAsync(string cep)
    {
        var httpClient = _httpClientFactory.CreateClient();

        var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var json = JsonSerializer.Deserialize<CepOutputModel>(content, options);

        var address = new AddressOutputModel(json.Cep, json.Logradouro, "", json.Complemento, json.Bairro, json.Localidade, json.UF);

        return ApiResponse<AddressOutputModel>.Ok(address);
    }
}
