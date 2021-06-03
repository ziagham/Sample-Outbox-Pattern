using Events.Users;
using Infrastructure.Core.Commands;
using Infrastructure.Core.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MessageService.EventHandlers
{
    public class UserDeletedEventHandler : IEventHandler<UserCreatedEvent>
    {
        private readonly ICommandBus _commandBus;

        public UserDeletedEventHandler(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        public async Task Handle(UserCreatedEvent @event, CancellationToken cancellationToken)
        {
            System.Console.WriteLine(@event.FirstName);
            await Task.CompletedTask;
        }
    }
}