using Microsoft.EntityFrameworkCore;
using PackerApp.Application.Services;
using PackerApp.Infrastructure.EFCore.Contexts;
using PackerApp.Infrastructure.EFCore.Models;

namespace PackerApp.Infrastructure.Services;

public class PackingListReadService : IPackingListReadService
{
    private readonly DbSet<PackingListReadModel> _packingLists;
    public PackingListReadService(ApplicationReadDbContext context) => _packingLists = context.PackingLists;
    public Task<bool> ExistByNameAsync(string name)
        => _packingLists.AnyAsync(pl => pl.Name == name);
}
