using Catalog.Application.Commands.UpdateType;

namespace Catalog.Application.Validator;
public class UpdateTypeCommandValidator : AbstractValidator<UpdateTypeCommand>
{
    public UpdateTypeCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Type Id is required.");

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