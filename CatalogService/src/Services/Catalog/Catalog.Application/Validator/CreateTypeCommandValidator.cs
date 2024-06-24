using Catalog.Application.Commands.CreateType;

namespace Catalog.Application.Validator;

public class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
{
    public CreateTypeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(2, 150)
            .WithMessage("Name must be between 2 and 150 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .Length(10, 500)
            .WithMessage("Description must be between 10 and 500 characters.");
    }
}