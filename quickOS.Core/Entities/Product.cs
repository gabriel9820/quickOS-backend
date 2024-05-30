namespace quickOS.Core.Entities;

public class Product : MultiTenantEntity
{
    public int Code { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal? CostPrice { get; private set; }
    public decimal? ProfitMargin { get; private set; }
    public decimal SellingPrice { get; private set; }
    public decimal Stock { get; private set; }
    public bool IsActive { get; private set; }

    /* Foreign Keys */
    public int UnitOfMeasurementId { get; private set; }

    /* Navigation */
    public UnitOfMeasurement UnitOfMeasurement { get; private set; }
    public ICollection<ServiceOrderProduct>? ServiceOrderProducts { get; private set; }

    private Product() { }

    public Product(int code, string name, string description, decimal? costPrice, decimal? profitMargin, decimal sellingPrice, decimal stock, bool isActive, UnitOfMeasurement unitOfMeasurement)
    {
        Code = code;
        Name = name;
        Description = description;
        CostPrice = costPrice;
        ProfitMargin = profitMargin;
        SellingPrice = sellingPrice;
        Stock = stock;
        UnitOfMeasurement = unitOfMeasurement;
        IsActive = isActive;
    }

    public void UpdateCode(int code)
    {
        Code = code;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateDescription(string description)
    {
        Description = description;
    }

    public void UpdateCostPrice(decimal? costPrice)
    {
        CostPrice = costPrice;
    }

    public void UpdateProfitMargin(decimal? profitMargin)
    {
        ProfitMargin = profitMargin;

        if (profitMargin.HasValue && CostPrice.HasValue)
        {
            SellingPrice = (decimal)(CostPrice * (1 + profitMargin / 100));
        }
    }

    public void UpdateSellingPrice(decimal sellingPrice)
    {
        SellingPrice = sellingPrice;
    }

    public void UpdateStock(decimal stock)
    {
        Stock = stock;
    }

    public void UpdateUnitOfMeasurement(UnitOfMeasurement unitOfMeasurement)
    {
        UnitOfMeasurement = unitOfMeasurement;
    }

    public void UpdateIsActive(bool isActive)
    {
        IsActive = isActive;
    }
}
