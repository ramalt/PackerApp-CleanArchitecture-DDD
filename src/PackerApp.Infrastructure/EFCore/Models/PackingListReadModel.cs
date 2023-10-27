namespace PackerApp.Infrastructure.EFCore.Models;

public class PackingListReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public LocalizationReadModel Localization { get; set; }
        public IEnumerable<PackingItemReadModel> Items { get; set; }
    }
