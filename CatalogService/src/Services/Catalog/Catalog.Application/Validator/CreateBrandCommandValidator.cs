namespace Catalog.Application.Validator;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Brand Name is required")
            .Length(2, 150).WithMessage("Brand Name must be between 2 and 150 characters");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required")
            .Length(5, 500).WithMessage("Description must be between 5 and 500 characters");
    }
}