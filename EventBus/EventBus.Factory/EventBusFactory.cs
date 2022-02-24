using EventBus.Base;
using EventBus.Base.İnterfaces;
using EventBus.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Factory
{
    public class EventBusFactory
    {
        //gelen parametreye göre azure veya rabbitmq ya bağlanmak için kullanıyoruz.
        // RabbitMQ=0, AzureServiceBus=1

        public static IEventBus Create(EventBusConfig config, IServiceProvider serviceProvider)
        {
            return config.EventBusType switch
            {
                EventBusType.AzureServiceBus => new EventBusServiceBus(config, serviceProvider),
                _ => new EventBusRabbitMQ(config, serviceProvider),
            };
        }
    }
}
