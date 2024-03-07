using System.ComponentModel.DataAnnotations;

namespace quickOS.Application.DTOs.InputModels;

public class TenantInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string Name { get; set; } = string.Empty;
}
