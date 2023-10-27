namespace PackerApp.Infrastructure.EFCore.Models;

public class PackingItemReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public uint Quantity { get; set; }
    public bool IsPacked { get; set; }
    public PackingListReadModel PackingList { get; set; }
}
