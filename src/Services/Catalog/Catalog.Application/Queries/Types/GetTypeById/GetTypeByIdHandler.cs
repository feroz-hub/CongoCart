namespace Catalog.Application.Queries.Types.GetTypeById;

public class GetTypeByIdQueryHandler(ITypesRepository typeRepository) : IQueryHandler<GetTypeByIdQuery, GetTypeByIdResult>
{
    public async Task<GetTypeByIdResult> Handle(GetTypeByIdQuery query, CancellationToken cancellationToken)
    {
        var type = await typeRepository.GetTypeById(query.Id);
        return new GetTypeByIdResult(type);
    }
}