using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Application.Mappings;

public static class ProductMapping
{
    public static async Task<Product> ToEntity(this ProductInputModel inputModel, IUnitOfMeasurementRepository unitOfMeasurementRepository)
    {
        var unitOfMeasurement = await unitOfMeasurementRepository.GetByExternalIdAsync(inputModel.UnitOfMeasurement);

        return new Product(
            inputModel.Code,
            inputModel.Name,
            inputModel.Description,
            inputModel.CostPrice,
            inputModel.ProfitMargin,
            inputModel.SellingPrice,
            inputModel.Stock,
            inputModel.IsActive,
            unitOfMeasurement);
    }

    public static ProductOutputModel ToOutputModel(this Product product)
    {
        var unitOfMeasurementOutputModel = product.UnitOfMeasurement != null
            ? new UnitOfMeasurementOutputModel(
                product.UnitOfMeasurement.ExternalId,
                product.UnitOfMeasurement.Name,
                product.UnitOfMeasurement.Abbreviation)
            : null;

        return new ProductOutputModel(
            product.ExternalId,
            product.Code,
            product.Name,
            product.Description,
            product.CostPrice,
            product.ProfitMargin,
            product.SellingPrice,
            product.Stock,
            product.IsActive,
            unitOfMeasurementOutputModel);
    }

    public static IEnumerable<ProductOutputModel> ToOutputModel(this IEnumerable<Product> products)
    {
        return products.Select(product => product.ToOutputModel());
    }
}
