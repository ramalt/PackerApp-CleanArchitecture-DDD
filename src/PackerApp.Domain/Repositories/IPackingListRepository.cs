using PackerApp.Domain.Entities;
using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Repositories;

/*
    universal interface
*/
public interface IPackingListRepository
    {
        Task<PackingList> GetAsync(PackingListId id);
        Task AddAsync(PackingList packingList);
        Task UpdateAsync(PackingList packingList);
        Task DeleteAsync(PackingList packingList);
    }
