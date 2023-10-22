using PackerApp.Domain.Entities;
using PackerApp.Domain.ValueObjects;
using PackerApp.Shared.Abstractions.Domain;

namespace PackerApp.Domain.Events;

public record PackingItemAdded(PackingList PackingList, PackingItem PackingItem) : IDomainEvent
{
    
}
