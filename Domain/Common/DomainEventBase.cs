namespace Domain.Common;

public class DomainEventBase : IDomainEvent
{
    public Guid Id { get; init; }
    public DateTime OccurredOn { get; init; }
    public DomainEventBase()
    {
        this.Id = Guid.NewGuid();
        this.OccurredOn = DateTime.UtcNow;
    }
}

