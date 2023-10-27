using PackerApp.Application.Dtos;
using PackerApp.Shared.Abstractions.Queries;

namespace PackerApp.Application.Queries;

public class SearchPackingListQuery : IQuery<IEnumerable<PackingListDto>>
{
    public string SearchField{ get; set; }
}
