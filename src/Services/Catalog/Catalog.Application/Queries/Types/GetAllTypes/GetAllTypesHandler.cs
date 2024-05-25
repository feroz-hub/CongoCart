namespace Catalog.Application.Queries.Types.GetAllTypes;

public class GetAllTypesQueryHandler(ITypesRepository typeRepository) : IQueryHandler<GetAllTypesQuery, GetAllTypesResult>
{
    public async Task<GetAllTypesResult> Handle(GetAllTypesQuery query, CancellationToken cancellationToken)
    {
        var types = await typeRepository.GetAllTypes(cancellationToken);
        return new GetAllTypesResult(types);
    }
}