using Infrastructure.Core.Events;
using System;

namespace Events.Users
{
    public class UserDeletedEvent : Event
    {
        public Guid UserId { get; set; }
    }
}