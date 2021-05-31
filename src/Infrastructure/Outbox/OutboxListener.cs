using Infrastructure.Core.Events;
using Infrastructure.MessageBrokers;
using Infrastructure.Outbox.Stores;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure.Outbox
{
    public class OutboxListener : IOutboxListener
    {
        private readonly IOutboxStore _store;

        public OutboxListener(IOutboxStore store)
        {
            _store = store;
        }

        public virtual async Task Commit(OutboxMessage message)
        {
            await _store.Add(message);
        }

        public virtual async Task Commit<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var outboxMessage = new OutboxMessage
            { 
                Type = MessageBrokersHelper.GetTypeName<TEvent>(),
                Data = @event == null ? "{}" : JsonSerializer.Serialize(@event)
            };

            await Commit(outboxMessage);
        }
    }
}