using Microsoft.EntityFrameworkCore;
using PackerApp.Domain.Entities;
using PackerApp.Domain.Repositories;
using PackerApp.Domain.ValueObjects;
using PackerApp.Infrastructure.EFCore.Contexts;

namespace PackerApp.Infrastructure.Repositories;

public class PackingListRepository : IPackingListRepository
{
    private readonly DbSet<PackingList> _packingLists;
    private readonly ApplicationWriteDbContext _context;

    public PackingListRepository(ApplicationWriteDbContext context)
    {
        _context = context;
        _packingLists = _context.PackingLists;
    }

    public Task<PackingList> GetAsync(PackingListId id) =>
        _packingLists.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

    public async Task AddAsync(PackingList packingList)
    {
        await _packingLists.AddAsync(packingList);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PackingList packingList)
    {
        _packingLists.Update(packingList);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PackingList packingList)
    {
        _packingLists.Remove(packingList);
        await _context.SaveChangesAsync();
    }
}
