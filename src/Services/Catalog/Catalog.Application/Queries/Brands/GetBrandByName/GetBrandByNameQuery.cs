namespace Catalog.Application.Queries.Brands.GetBrandByName;

public record GetBrandByNameQuery(string Name) : IQuery<GetBrandByNameResult>;

public record GetBrandByNameResult(ProductBrand? Brand);

public class GetBrandByNameQueryValidator:AbstractValidator<GetBrandByNameQuery>
{
    public GetBrandByNameQueryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}