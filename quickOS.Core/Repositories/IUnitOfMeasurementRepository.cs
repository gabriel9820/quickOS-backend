using quickOS.Core.Entities;

namespace quickOS.Core.Repositories;

public interface IUnitOfMeasurementRepository
{
    Task<IEnumerable<UnitOfMeasurement>> FillAutocompleteAsync();
}
