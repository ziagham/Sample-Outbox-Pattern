using Infrastructure.Core.Events;
using System;

namespace Events.Users
{
    public class UserCreatedEvent : IEvent
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}