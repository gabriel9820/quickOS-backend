using System.ComponentModel.DataAnnotations;
using quickOS.Core.Models;

namespace quickOS.Application.DTOs.InputModels;

public class AccountReceivableInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateOnly IssueDate { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateOnly DueDate { get; set; }

    public DateOnly? PaymentDate { get; set; }

    [MaxLength(20, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? DocumentNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(0, 99999999.99, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public decimal Value { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public bool IsPaidOut { get; set; }

    public Guid? Customer { get; set; }
}

public class AccountReceivableQueryParams : QueryParams
{
    public DateOnly? IssueDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public DateOnly? PaymentDate { get; set; }
    public string? DocumentNumber { get; set; } = string.Empty;
    public bool? IsPaidOut { get; set; }
    public Guid? Customer { get; set; }
}