using quickOS.Core.Models;

namespace quickOS.Application.DTOs.InputModels;

public class ServiceProvidedQueryParams : QueryParams
{
    public int Code { get; set; }
    public string Name { get; set; } = string.Empty;
}
