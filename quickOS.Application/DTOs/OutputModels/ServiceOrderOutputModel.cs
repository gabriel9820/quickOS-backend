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

    public ServiceOrderOutputModel(Guid externalId, int number, DateTime date, ServiceOrderStatus status, string? equipmentDescription, string? problemDescription, string? technicalReport, decimal totalPrice, CustomerOutputModel customer, UserOutputModel technician)
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
    }
}
