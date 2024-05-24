namespace quickOS.Application.DTOs.OutputModels;

public class ProductOutputModel
{
    public Guid ExternalId { get; private set; }
    public int Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal CostPrice { get; private set; }
    public decimal ProfitMargin { get; private set; }
    public decimal SellingPrice { get; private set; }
    public decimal Stock { get; private set; }
    public bool IsActive { get; private set; }
    public UnitOfMeasurementOutputModel UnitOfMeasurement { get; private set; }

    public ProductOutputModel(Guid externalId, int code, string name, string description, decimal costPrice, decimal profitMargin, decimal sellingPrice, decimal stock, bool isActive, UnitOfMeasurementOutputModel unitOfMeasurement)
    {
        ExternalId = externalId;
        Code = code;
        Name = name;
        Description = description;
        CostPrice = costPrice;
        ProfitMargin = profitMargin;
        SellingPrice = sellingPrice;
        Stock = stock;
        IsActive = isActive;
        UnitOfMeasurement = unitOfMeasurement;
    }
}
