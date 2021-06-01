using Infrastructure.Core.Events;
using Infrastructure.EventStores.Aggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.EventStores
{
    public interface IEventStore
    {
        Task AppendEvent<TAggregate>(Guid aggregateId, IEvent @event, int? expectedVersion = null, Func<StreamState, Task> action = null) where TAggregate : IAggregate;

        Task<TAggregate> AggregateStream<TAggregate>(Guid aggregateId, int? version = null, DateTime? createdUtc = null) where TAggregate : IAggregate;
        Task<ICollection<TAggregate>> AggregateStream<TAggregate>(ICollection<Guid> ids) where TAggregate : IAggregate;

        Task<IEnumerable<StreamState>> GetEvents(Guid aggregateId, int? version = null, DateTime? createdUtc = null);

        Task Store<TAggregate>(TAggregate aggregate, Func<StreamState, Task> action = null) where TAggregate : IAggregate;
        Task Store<TAggregate>(ICollection<TAggregate> aggregates, Func<StreamState, Task> action = null) where TAggregate : IAggregate;
    }
}