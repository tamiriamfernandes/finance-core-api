using FluentValidation;
using financial.Model.DTOs.Client;

namespace financial.Application.Validators;

public class CustomerValidation : AbstractValidator<InputCustomerDto>
{
    public CustomerValidation()
    {
        RuleFor(customer => customer.name)
           .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
           .MinimumLength(5).WithMessage("O nome do cliente deve conter no minimmo 5 caracteres.")
           .MaximumLength(250).WithMessage("O nome do cliente não pode ter mais de 250 caracteres.");

        RuleFor(customer => customer.phone)
          .NotEmpty().WithMessage("O telefone do cliente é obrigatório.");
    }
}
