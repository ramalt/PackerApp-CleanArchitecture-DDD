using PackerApp.Application.Dtos;
using PackerApp.Shared.Abstractions.Queries;

namespace PackerApp.Application.Queries;

public class GetPackingListQuery : IQuery<PackingListDto>
    {
        public Guid Id { get; set; }
    }
