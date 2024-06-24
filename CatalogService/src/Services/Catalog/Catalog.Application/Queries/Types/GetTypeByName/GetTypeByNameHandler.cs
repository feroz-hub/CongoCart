namespace Catalog.Application.Queries.Types.GetTypeByName;

public class GetTypeByNameQueryHandler(ITypesRepository typeRepository) : IQueryHandler<GetTypeByNameQuery, GetTypeByNameResult>
{
    public async Task<GetTypeByNameResult> Handle(GetTypeByNameQuery query, CancellationToken cancellationToken)
    {
        var type = await typeRepository.GetTypeByName(query.Name);
        return new GetTypeByNameResult(type);
    }
}