﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Outbox
{
    public class OutboxMessage
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime Created { get; private set; } = DateTime.UtcNow;
        public string Type { get; set; }
        public string Data { get; set; }
        public DateTime? Processed { get; set; }
    }
}
