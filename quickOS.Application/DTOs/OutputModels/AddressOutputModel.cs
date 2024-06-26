namespace quickOS.Application.DTOs.OutputModels;

public class AddressOutputModel
{
    public string ZipCode { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string Details { get; private set; }
    public string Neighborhood { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }

    public AddressOutputModel(string zipCode, string street, string number, string details, string neighborhood, string city, string state)
    {
        ZipCode = zipCode;
        Street = street;
        Number = number;
        Details = details;
        Neighborhood = neighborhood;
        City = city;
        State = state;
    }
}
