﻿using System.ComponentModel.DataAnnotations;
using quickOS.Application.Validations;
using quickOS.Core.Enums;
using quickOS.Core.Models;

namespace quickOS.Application.DTOs.InputModels;

public class CustomerInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public int Code { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public CustomerType Type { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(14, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(18, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}|\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$", ErrorMessage = "O campo {0} é inválido")]
    [DocumentValidation]
    public string Document { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(15, ErrorMessage = "O campo {0} deve conter {1} caracteres")]
    [RegularExpression(@"^\(\d{2}\)\ 9\d{4}-\d{4}$", ErrorMessage = "O campo {0} é inválido")]
    public string Cellphone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public bool IsActive { get; set; }

    public AddressInputModel? Address { get; set; }
}

public class CustomerQueryParams : QueryParams
{
    public int? Code { get; set; }
    public CustomerType[]? Types { get; set; }
    public string? Document { get; set; } = string.Empty;
    public string? FullName { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public bool? IsActive { get; set; }
}
