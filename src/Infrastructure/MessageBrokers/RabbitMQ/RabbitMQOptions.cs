using RawRabbit.Configuration;

namespace Infrastructure.MessageBrokers.RabbitMQ
{
    public class RabbitMQOptions : RawRabbitConfiguration
    {
        public new QueueOptions Queue { get; set; }
        public new ExchangeOptions Exchange { get; set; }
    }

    public class QueueOptions : GeneralQueueConfiguration
    {
        public string Name { get; set; }
    }

    public class ExchangeOptions : GeneralExchangeConfiguration
    {
        public string Name { get; set; }
    }
}