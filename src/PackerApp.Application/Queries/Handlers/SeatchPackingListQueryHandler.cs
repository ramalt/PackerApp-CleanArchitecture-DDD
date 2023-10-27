using PackerApp.Application.Dtos;
using PackerApp.Shared.Abstractions.Queries;

namespace PackerApp.Application.Queries.Handlers;

public class SeatchPackingListQueryHandler : IQueryHandler<SearchPackingListQuery, IEnumerable<PackingListDto>>
{

    public Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingListQuery query)
    {
        throw new NotImplementedException();
    }
}
