using Microsoft.EntityFrameworkCore;
using PackerApp.Application.Dtos;
using PackerApp.Application.Queries;
using PackerApp.Infrastructure.EFCore.Contexts;
using PackerApp.Infrastructure.EFCore.Models;
using PackerApp.Shared.Abstractions.Queries;

namespace PackerApp.Infrastructure.Queries.Handlers;

public class SeatchPackingListQueryHandler
    : IQueryHandler<SearchPackingListQuery, IEnumerable<PackingListDto>>
{
    private readonly DbSet<PackingListReadModel> _packingLists;

    public SeatchPackingListQueryHandler(ApplicationReadDbContext context) =>
        _packingLists = context.PackingLists;

    public async Task<IEnumerable<PackingListDto>> HandleAsync(SearchPackingListQuery query)
    {
        var dbQuery = _packingLists.Include(pl => pl.Items).AsQueryable();

        if (query.SearchField is not null)
        {
            dbQuery = dbQuery.Where(
                pl =>
                    EF.Functions.ILike(
                        pl.Name,
                        $"%{query.SearchField}%"
                    )
            );
        }

        return await dbQuery.Select(pl => pl.toDto()).AsNoTracking().ToListAsync();
    }
}
