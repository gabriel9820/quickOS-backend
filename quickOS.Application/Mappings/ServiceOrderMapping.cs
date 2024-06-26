using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Application.Mappings;

public static class ServiceOrderMapping
{
    public static async Task<ServiceOrder> ToEntity(this ServiceOrderInputModel inputModel, ICustomerRepository customerRepository, IUserRepository userRepository)
    {
        var customer = await customerRepository.GetByExternalIdAsync(inputModel.Customer);
        var technician = await userRepository.GetByExternalIdAsync(inputModel.Technician);

        return new ServiceOrder(
            inputModel.Number,
            inputModel.Date,
            inputModel.Status,
            inputModel.EquipmentDescription,
            inputModel.ProblemDescription,
            inputModel.TechnicalReport,
            customer,
            technician,
            null,
            null);
    }

    public static ServiceOrderOutputModel ToOutputModel(this ServiceOrder serviceOrder)
    {
        var customer = serviceOrder.Customer.ToOutputModel();
        var technician = serviceOrder.Technician.ToOutputModel();

        return new ServiceOrderOutputModel(
            serviceOrder.ExternalId,
            serviceOrder.Number,
            serviceOrder.Date,
            serviceOrder.Status,
            serviceOrder.EquipmentDescription,
            serviceOrder.ProblemDescription,
            serviceOrder.TechnicalReport,
            serviceOrder.TotalPrice,
            customer,
            technician);
    }

    public static IEnumerable<ServiceOrderOutputModel> ToOutputModel(this IEnumerable<ServiceOrder> serviceOrders)
    {
        return serviceOrders.Select(serviceOrder => serviceOrder.ToOutputModel());
    }
}
