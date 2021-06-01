using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Outbox
{
    public interface IOutboxListener
    {
        Task Commit<T>(T message);
    }
}
