using quickOS.Application.DTOs.InputModels;
using quickOS.Application.DTOs.OutputModels;
using quickOS.Core.ValueObjects;

namespace quickOS.Application.Mappings;

public static class AddressMapping
{
    public static Address ToValueObject(this AddressInputModel inputModel)
    {
        return new Address(
            inputModel.ZipCode,
            inputModel.Street,
            inputModel.Number,
            inputModel.Details,
            inputModel.Neighborhood,
            inputModel.City,
            inputModel.State);
    }

    public static AddressOutputModel ToOutputModel(this Address address)
    {
        return new AddressOutputModel(
            address.ZipCode,
            address.Street,
            address.Number,
            address.Details,
            address.Neighborhood,
            address.City,
            address.State);
    }
}
