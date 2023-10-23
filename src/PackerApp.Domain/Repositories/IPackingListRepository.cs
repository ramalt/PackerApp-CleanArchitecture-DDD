using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Repositories;

/*
    universal interface
*/
public interface IPackingListRepository
    {
        Task<Entities.PackingList> GetAsync(PackingListId id);
        Task AddAsync(Entities.PackingList packingList);
        Task UpdateAsync(Entities.PackingList packingList);
        Task DeleteAsync(Entities.PackingList packingList);
    }
