using Catalog.Application.Commands.CreateProduct;
using FluentValidation;

namespace Catalog.Application.Validator;

public class CreateProductCommandValidator:AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.ProductDto.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.ProductDto.TypeId).NotEmpty().WithMessage("Category is required");
        RuleFor(x => x.ProductDto.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.ProductDto.ImageFile).NotEmpty().WithMessage("Image file is required");
        RuleFor(x => x.ProductDto.Price).GreaterThan(0).WithMessage("Price must be greater that 0");
        RuleFor(x=>x.ProductDto.BrandId).NotEmpty().WithMessage("Brand is required");
    }
}