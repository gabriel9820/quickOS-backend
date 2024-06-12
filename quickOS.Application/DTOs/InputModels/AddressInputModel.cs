using System.ComponentModel.DataAnnotations;

namespace quickOS.Application.DTOs.InputModels;

public class AddressInputModel
{
    [MaxLength(9, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O campo {0} é inválido")]
    public string? ZipCode { get; set; } = string.Empty;

    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? Street { get; set; } = string.Empty;

    [MaxLength(30, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? Number { get; set; } = string.Empty;

    [MaxLength(100, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? Details { get; set; } = string.Empty;

    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? Neighborhood { get; set; } = string.Empty;

    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? City { get; set; } = string.Empty;

    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string? State { get; set; } = string.Empty;
}
