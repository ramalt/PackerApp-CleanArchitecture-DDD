using PackerApp.Application.Dtos;
using PackerApp.Application.Queries;
using PackerApp.Shared.Abstractions.Queries;

namespace PackerApp.Infrastructure.Queries.Handlers;

public class GetPackingListQueryHandler : IQueryHandler<GetPackingListQuery, PackingListDto>
{

    public async Task<PackingListDto> HandleAsync(GetPackingListQuery query)
    {
        // var packingList  = await _repository.GetAsync(query.Id);
        throw new NotImplementedException("TODO: before build infrastructure layer");

    }
}
