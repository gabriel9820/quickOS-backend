using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Application.Mappings;

public static class ServiceOrderProductMapping
{
    public static async Task<ServiceOrderProduct> ToEntity(this ServiceOrderProductInputModel inputModel, IProductRepository productRepository)
    {
        var product = await productRepository.GetByExternalIdAsync(inputModel.Product);

        return new ServiceOrderProduct(
            inputModel.Item,
            product,
            inputModel.Quantity,
            inputModel.Price);
    }

    public static ServiceOrderProductOutputModel ToOutputModel(this ServiceOrderProduct serviceOrderProduct)
    {
        var product = serviceOrderProduct.Product.ToOutputModel();

        return new ServiceOrderProductOutputModel(
            serviceOrderProduct.ExternalId,
            serviceOrderProduct.Item,
            product,
            serviceOrderProduct.Quantity,
            serviceOrderProduct.Price,
            serviceOrderProduct.TotalPrice);
    }

    public static IEnumerable<ServiceOrderProductOutputModel> ToOutputModel(this IEnumerable<ServiceOrderProduct> serviceOrderProducts)
    {
        return serviceOrderProducts.Select(serviceOrderProduct => serviceOrderProduct.ToOutputModel());
    }
}
