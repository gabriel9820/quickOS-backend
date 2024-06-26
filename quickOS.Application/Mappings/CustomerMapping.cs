using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.Entities;

namespace quickOS.Application.Mappings;

public static class CustomerMapping
{
    public static Customer ToEntity(this CustomerInputModel inputModel)
    {
        var address = inputModel.Address?.ToValueObject();

        return new Customer(
            inputModel.Code,
            inputModel.Type,
            inputModel.Document,
            inputModel.FullName,
            inputModel.Cellphone,
            inputModel.Email,
            inputModel.IsActive,
            address);
    }

    public static CustomerOutputModel ToOutputModel(this Customer customer)
    {
        var address = customer.Address?.ToOutputModel();

        return new CustomerOutputModel(
            customer.ExternalId,
            customer.Code,
            customer.Type,
            customer.Document,
            customer.FullName,
            customer.Cellphone,
            customer.Email,
            customer.IsActive,
            address);
    }

    public static IEnumerable<CustomerOutputModel> ToOutputModel(this IEnumerable<Customer> customers)
    {
        return customers.Select(customer => customer.ToOutputModel());
    }
}
