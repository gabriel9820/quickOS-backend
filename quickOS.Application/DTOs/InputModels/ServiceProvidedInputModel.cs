﻿using System.ComponentModel.DataAnnotations;
using quickOS.Core.Models;

namespace quickOS.Application.DTOs.InputModels;

public class ServiceProvidedInputModel
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

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(0, 99999999.99, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public bool IsActive { get; set; }
}

public class ServiceProvidedQueryParams : QueryParams
{
    public int? Code { get; set; }
    public string? Name { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public bool? IsActive { get; set; }
}
