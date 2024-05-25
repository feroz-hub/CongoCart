namespace Catalog.Application.Validator;

public class DeleteBrandCommandValidator : AbstractValidator<DeleteBrandCommand>
{
    public DeleteBrandCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Brand Id is required");
    }
}