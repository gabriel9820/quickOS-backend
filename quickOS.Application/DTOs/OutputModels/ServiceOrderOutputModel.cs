using quickOS.Core.Enums;

namespace quickOS.Application.DTOs.OutputModels;

public class ServiceOrderOutputModel
{
    public Guid ExternalId { get; private set; }
    public int Number { get; private set; }
    public DateTime Date { get; private set; }
    public ServiceOrderStatus Status { get; private set; }
    public string? EquipmentDescription { get; private set; }
    public string? ProblemDescription { get; private set; }
    public string? TechnicalReport { get; private set; }
    public decimal TotalPrice { get; private set; }
    public CustomerOutputModel Customer { get; private set; }
    public UserOutputModel Technician { get; private set; }
    public IEnumerable<ServiceOrderServiceOutputModel> Services { get; private set; }
    public IEnumerable<ServiceOrderProductOutputModel> Products { get; private set; }

    public ServiceOrderOutputModel(
        Guid externalId,
        int number,
        DateTime date,
        ServiceOrderStatus status,
        string? equipmentDescription,
        string? problemDescription,
        string? technicalReport,
        decimal totalPrice,
        CustomerOutputModel customer,
        UserOutputModel technician,
        IEnumerable<ServiceOrderServiceOutputModel> services,
        IEnumerable<ServiceOrderProductOutputModel> products)
    {
        ExternalId = externalId;
        Number = number;
        Date = date;
        Status = status;
        EquipmentDescription = equipmentDescription;
        ProblemDescription = problemDescription;
        TechnicalReport = technicalReport;
        TotalPrice = totalPrice;
        Customer = customer;
        Technician = technician;
        Services = services;
        Products = products;
    }
}

public class ServiceOrderServiceOutputModel
{
    public Guid ExternalId { get; private set; }
    public int Item { get; private set; }
    public ServiceProvidedOutputModel Service { get; private set; }
    public double Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal TotalPrice { get; private set; }

    public ServiceOrderServiceOutputModel(Guid externalId, int item, ServiceProvidedOutputModel service, double quantity, decimal price, decimal totalPrice)
    {
        ExternalId = externalId;
        Item = item;
        Service = service;
        Quantity = quantity;
        Price = price;
        TotalPrice = totalPrice;
    }
}

public class ServiceOrderProductOutputModel
{
    public Guid ExternalId { get; private set; }
    public int Item { get; private set; }
    public ProductOutputModel Product { get; private set; }
    public double Quantity { get; private set; }
    public decimal Price { get; private set; }
    public decimal TotalPrice { get; private set; }

    public ServiceOrderProductOutputModel(Guid externalId, int item, ProductOutputModel product, double quantity, decimal price, decimal totalPrice)
    {
        ExternalId = externalId;
        Item = item;
        Product = product;
        Quantity = quantity;
        Price = price;
        TotalPrice = totalPrice;
    }
}
