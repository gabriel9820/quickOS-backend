using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Application.Mappings;

public static class ServiceOrderServiceMapping
{
    public static async Task<ServiceOrderService> ToEntity(this ServiceOrderServiceInputModel inputModel, IServiceProvidedRepository serviceProvidedRepository)
    {
        var service = await serviceProvidedRepository.GetByExternalIdAsync(inputModel.Service);

        return new ServiceOrderService(
            inputModel.Item,
            service,
            inputModel.Quantity,
            inputModel.Price);
    }

    public static ServiceOrderServiceOutputModel ToOutputModel(this ServiceOrderService serviceOrderService)
    {
        var service = serviceOrderService.Service.ToOutputModel();

        return new ServiceOrderServiceOutputModel(
            serviceOrderService.ExternalId,
            serviceOrderService.Item,
            service,
            serviceOrderService.Quantity,
            serviceOrderService.Price,
            serviceOrderService.TotalPrice);
    }

    public static IEnumerable<ServiceOrderServiceOutputModel> ToOutputModel(this IEnumerable<ServiceOrderService> serviceOrderServices)
    {
        return serviceOrderServices.Select(serviceOrderService => serviceOrderService.ToOutputModel());
    }
}
