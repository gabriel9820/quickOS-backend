using System.ComponentModel.DataAnnotations;
using quickOS.Core.Models;

namespace quickOS.Application.DTOs.InputModels;

public class ProductInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public int Code { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string Description { get; set; } = string.Empty;

    [Range(0, 99999999.99, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public decimal CostPrice { get; set; }

    [Range(0, 99999999.99, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public decimal ProfitMargin { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(0, 99999999.99, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public decimal SellingPrice { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(0, 99999999.99, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public decimal Stock { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public bool IsActive { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid UnitOfMeasurement { get; set; }
}

public class ProductQueryParams : QueryParams
{
    public int? Code { get; set; }
    public string? Name { get; set; } = string.Empty;
    public decimal? SellingPrice { get; set; }
    public decimal? Stock { get; set; }
    public bool? IsActive { get; set; }
    public Guid[]? UnitsOfMeasurement { get; set; }
}
