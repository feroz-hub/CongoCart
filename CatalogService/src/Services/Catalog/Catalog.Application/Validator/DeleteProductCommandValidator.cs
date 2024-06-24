using Catalog.Application.Commands.DeleteProduct;

namespace Catalog.Application.Validator;

public class DeleteProductCommandValidator:AbstractValidator<DeleteProductCommand>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required");
    }
}