﻿using MassTransit;
using MassTransit.Configuration;

namespace BankAccount.Transactions.Core.Consumers
{
    public class ConsumerEndpointConfiguration : ConsumerDefinition<TransactionConsumer>
    {
        public ConsumerEndpointConfiguration()
        {
            EndpointName = "create-transaction";
        }

        protected void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<ConsumerEndpointConfiguration> consumerConfigurator)
        {
            endpointConfigurator.ConcurrentMessageLimit = 5;
        }
    }
}