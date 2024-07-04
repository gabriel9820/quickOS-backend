using System.ComponentModel.DataAnnotations;
using quickOS.Core.Enums;
using quickOS.Core.Models;

namespace quickOS.Application.DTOs.InputModels;

public class ServiceOrderInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public int Number { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public ServiceOrderStatus Status { get; set; }

    [MaxLength(1000, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? EquipmentDescription { get; set; } = string.Empty;

    [MaxLength(1000, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? ProblemDescription { get; set; } = string.Empty;

    [MaxLength(1000, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? TechnicalReport { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid Customer { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid Technician { get; set; }

    public IEnumerable<ServiceOrderServiceInputModel> Services { get; set; } = [];
}

public class ServiceOrderServiceInputModel
{
    public Guid? ExternalId { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public int Item { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid Service { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(0, 9999.99, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public double Quantity { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(0, 99999999.99, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public decimal Price { get; set; }
}

public class ServiceOrderQueryParams : QueryParams
{
    public int? Number { get; set; }
    public DateTime? Date { get; set; }
    public ServiceOrderStatus[]? Status { get; set; }
    public Guid? Customer { get; set; }
    public Guid? Technician { get; set; }
}
