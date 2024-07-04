using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;

namespace quickOS.Application.Mappings;

public static class ServiceProvidedMapping
{
    public static ServiceProvidedOutputModel ToOutputModel(this ServiceProvided serviceProvided)
    {
        return new ServiceProvidedOutputModel(
            serviceProvided.ExternalId,
            serviceProvided.Code,
            serviceProvided.Name,
            serviceProvided.Description,
            serviceProvided.Price,
            serviceProvided.IsActive);
    }

    public static IEnumerable<ServiceProvidedOutputModel> ToOutputModel(this IEnumerable<ServiceProvided> services)
    {
        return services.Select(service => service.ToOutputModel());
    }
}
