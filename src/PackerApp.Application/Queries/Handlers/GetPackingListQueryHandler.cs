using PackerApp.Application.Dtos;
using PackerApp.Domain.Repositories;
using PackerApp.Shared.Abstractions.Queries;

namespace PackerApp.Application.Queries.Handlers;

public class GetPackingListQueryHandler : IQueryHandler<GetPackingListQuery, PackingListDto>
{

    public async Task<PackingListDto> HandleAsync(GetPackingListQuery query)
    {
        // var packingList  = await _repository.GetAsync(query.Id);
        throw new NotImplementedException("TODO: before build infrastructure layer");

    }
}
