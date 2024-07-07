using System.ComponentModel.DataAnnotations;

namespace quickOS.Application.DTOs.InputModels;

public class DashboardQueryParams
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [RegularExpression(@"^\d{4}-\d{2}$", ErrorMessage = "O campo {0} deve estar no formato YYYY-MM")]
    public string AccountsDate { get; set; } = string.Empty;
}
