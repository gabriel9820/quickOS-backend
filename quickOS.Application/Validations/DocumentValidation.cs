using System.ComponentModel.DataAnnotations;
using Flunt.Br;
using Flunt.Br.Extensions;

namespace quickOS.Application.Validations;

public class DocumentValidation : ValidationAttribute
{
    public DocumentValidation() : base("O campo {0} é inválido") { }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var contract = new Contract();
        var validation = contract.IsCnpjOrCPF(value.ToString(), "Document", "O campo Document (CPF/CNPJ) é inválido");

        if (validation.IsValid)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName), [validationContext.MemberName]);
    }
}
