using FluentValidation;

namespace Application.Features.Clients.Commands.CreateClientCommand;

public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} can not be empty")
            .MaximumLength(80).WithMessage("{PropertyName} can not exceed {MaxLength} charactors");

        RuleFor(p => p.FamilyName)
            .NotEmpty().WithMessage("{PropertyName} can not be empty")
            .MaximumLength(80).WithMessage("{PropertyName} can not exceed {MaxLength} charactors");

        RuleFor(p => p.DateOfBirth)
            .NotEmpty().WithMessage("Date of birth can not be empty");

        RuleFor(p => p.Phone)
            .NotEmpty().WithMessage("{PropertyName} can not be empty")
            .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} must have the format 0000-0000")
            .MaximumLength(9).WithMessage("{PropertyName} can not exceed {MaxLength} charactors");

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{PropertyName} can not be empty")
            .EmailAddress().WithMessage("{PropertyName} must be an email format")
            .MaximumLength(80).WithMessage("{PropertyName} can not exceed {MaxLength} charactors");
    }
}