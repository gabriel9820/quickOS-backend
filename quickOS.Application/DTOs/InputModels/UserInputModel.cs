using System.ComponentModel.DataAnnotations;
using quickOS.Core.Enums;
using quickOS.Core.Models;

namespace quickOS.Application.DTOs.InputModels;

public class UserInputModel
{
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
    public UserRole Role { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public bool IsActive { get; set; }
}

public class UserCreateInputModel : UserInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(8, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    public string Password { get; set; } = string.Empty;
}

public class UserQueryParams : QueryParams
{
    public string? FullName { get; set; } = string.Empty;
    public string? Cellphone { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public UserRole[]? Roles { get; set; }
    public bool? IsActive { get; set; }
}
