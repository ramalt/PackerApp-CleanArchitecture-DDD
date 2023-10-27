using Microsoft.EntityFrameworkCore;
using PackerApp.Domain.Entities;
using PackerApp.Domain.ValueObjects;
using PackerApp.Infrastructure.EFCore.Config;

namespace PackerApp.Infrastructure.EFCore.Contexts;

public class ApplicationWriteDbContext : DbContext
{
    public DbSet<PackingList> PackingLists { get; set; }
    public ApplicationWriteDbContext(DbContextOptions<ApplicationWriteDbContext> options): base(options) 
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("packings");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<PackingList>(configuration);
        modelBuilder.ApplyConfiguration<PackingItem>(configuration);
        base.OnModelCreating(modelBuilder);
    }
}
