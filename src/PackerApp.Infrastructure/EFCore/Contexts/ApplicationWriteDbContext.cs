using Microsoft.EntityFrameworkCore;
using PackerApp.Domain.Entities;

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
        base.OnModelCreating(modelBuilder);
    }
}
