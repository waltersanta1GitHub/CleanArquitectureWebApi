using Application.ViewModels;
using FluentValidation;

namespace Application.Validators;

public class RegistredUserValidator: AbstractValidator<RegistredUserModelView>
{
    public RegistredUserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty().WithMessage("El nombre es requerido");

        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("El correo es requerido")
            .EmailAddress().WithMessage("El coreo no tiene el formato valido");
    }
}
