using System.ComponentModel.DataAnnotations;

namespace quickOS.Application.DTOs.InputModels;

public class RegisterInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string TenantName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    public string OwnerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(14, ErrorMessage = "O campo {0} deve conter {1} caracteres")]
    [RegularExpression(@"^\(\d{2}\)9\d{4}-\d{4}$", ErrorMessage = "O campo {0} é inválido")]
    public string CellPhone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(1, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    [MaxLength(200, ErrorMessage = "O campo {0} deve conter no máximo {1} caracteres")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(8, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    public string Password { get; set; } = string.Empty;


}
