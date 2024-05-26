using quickOS.Application.DTOs.OutputModels;

namespace quickOS.Application.Interfaces;

public interface IUnitOfMeasurementService
{
    Task<ApiResponse<IEnumerable<UnitOfMeasurementOutputModel>>> FillAutocompleteAsync();
}
