using System.ComponentModel.DataAnnotations;

namespace quickOS.Application.DTOs.InputModels;

public class LoginInputModel
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Password { get; set; } = string.Empty;
}
