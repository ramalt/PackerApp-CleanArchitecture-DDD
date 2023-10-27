using Microsoft.EntityFrameworkCore;
using PackerApp.Infrastructure.EFCore.Config;
using PackerApp.Infrastructure.EFCore.Models;

namespace PackerApp.Infrastructure.EFCore.Contexts;

public class ApplicationReadDbContext : DbContext
{
    public DbSet<PackingListReadModel> PackingLists { get; set; }
    public ApplicationReadDbContext(DbContextOptions<ApplicationReadDbContext> options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("packings");
        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
        modelBuilder.ApplyConfiguration<PackingItemReadModel>(configuration);
        base.OnModelCreating(modelBuilder);
    }


}
