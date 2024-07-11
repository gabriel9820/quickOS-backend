using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;
using quickOS.Core.Repositories;

namespace quickOS.Application.Mappings;

public static class ServiceOrderMapping
{
    public static async Task<ServiceOrder> ToEntity(
        this ServiceOrderInputModel inputModel,
        ICustomerRepository customerRepository,
        IUserRepository userRepository,
        IServiceProvidedRepository serviceProvidedRepository,
        IProductRepository productRepository)
    {
        var customer = await customerRepository.GetByExternalIdAsync(inputModel.Customer);
        var technician = await userRepository.GetByExternalIdAsync(inputModel.Technician);

        var serviceOrder = new ServiceOrder(
            inputModel.Number,
            inputModel.Date,
            inputModel.Status,
            inputModel.EquipmentDescription,
            inputModel.ProblemDescription,
            inputModel.TechnicalReport,
            customer,
            technician);

        foreach (var serviceInputModel in inputModel.Services)
        {
            var service = await serviceInputModel.ToEntity(serviceProvidedRepository);
            serviceOrder.AddService(service);
        }

        foreach (var productInputModel in inputModel.Products)
        {
            var product = await productInputModel.ToEntity(productRepository);
            serviceOrder.AddProduct(product);
        }

        serviceOrder.CalculateTotalPrice();

        return serviceOrder;
    }

    public static ServiceOrderOutputModel ToOutputModel(this ServiceOrder serviceOrder)
    {
        var customer = serviceOrder.Customer.ToOutputModel();
        var technician = serviceOrder.Technician.ToOutputModel();
        var services = serviceOrder.Services.ToOutputModel();
        var products = serviceOrder.Products.ToOutputModel();

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
            technician,
            services,
            products);
    }

    public static IEnumerable<ServiceOrderOutputModel> ToOutputModel(this IEnumerable<ServiceOrder> serviceOrders)
    {
        return serviceOrders.Select(serviceOrder => serviceOrder.ToOutputModel());
    }
}
