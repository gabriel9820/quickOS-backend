using System.ComponentModel.DataAnnotations;

namespace quickOS.Core.Models;

public abstract class QueryParams
{
    [Range(1, int.MaxValue, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public int CurrentPage { get; set; } = 1;

    [Range(5, 100, ErrorMessage = "O campo {0} deve ser um valor entre {1} e {2}")]
    public int PageSize { get; set; } = 10;

    public string OrderBy { get; set; } = string.Empty;

    [RegularExpression("^(ASC|DESC)$", ErrorMessage = "O campo {0} é inválido")]
    public string OrderDirection { get; set; } = string.Empty;
}
