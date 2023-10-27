using Microsoft.EntityFrameworkCore;
using PackerApp.Application.Dtos;
using PackerApp.Application.Queries;
using PackerApp.Infrastructure.EFCore.Contexts;
using PackerApp.Infrastructure.EFCore.Models;
using PackerApp.Shared.Abstractions.Queries;

namespace PackerApp.Infrastructure.Queries.Handlers;

public class GetPackingListQueryHandler : IQueryHandler<GetPackingListQuery, PackingListDto>
{
    private readonly DbSet<PackingListReadModel> _packingLists;

    public GetPackingListQueryHandler(ApplicationReadDbContext context) =>
        _packingLists = context.PackingLists;

    public async Task<PackingListDto> HandleAsync(GetPackingListQuery query)
    {
        return await _packingLists
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.toDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
