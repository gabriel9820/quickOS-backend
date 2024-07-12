using System.ComponentModel.DataAnnotations;

namespace quickOS.Application.DTOs.InputModels;

public class SendResetPasswordLinkInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; } = string.Empty;
}

public class ResetPasswordInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Token { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [MinLength(8, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres")]
    public string NewPassword { get; set; } = string.Empty;
}
