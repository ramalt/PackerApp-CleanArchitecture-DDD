namespace PackerApp.Shared.Abstractions.Domain;

public abstract class AggregateRoot<TId>
{
    public TId Id { get; protected set; }
    public int Version { get; protected set; }

    private readonly List<IDomainEvent> _events = new();
    public IEnumerable<IDomainEvent> Events => _events;

    private bool _versionIncramented = false;

    protected void IncramentVersion()
    {
        if (_versionIncramented) return;

        Version++;
        _versionIncramented = true;
    }
    protected void AddEvent(IDomainEvent @event)
    {
        if (!_events.Any() && !_versionIncramented)
            Version++;
            _versionIncramented = true;

        _events.Add(@event);
    }
    public void ClearEvents() => _events.Clear();

}
