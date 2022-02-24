using EventBus.Base;
using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Factory
{
    public class EventBusServiceBus : BaseEventBus
    {
        public EventBusServiceBus(EventBusConfig config, IServiceProvider serviceProvider) : base(config, serviceProvider)
        {
        }

        public override void Publish(IntegrationEvent @event)
        {
            throw new NotImplementedException();
        }

        public override void Subscribe<T, TH>()
        {
            throw new NotImplementedException();
        }

        public override void UnSubscribe<T, TH>()
        {
            throw new NotImplementedException();
        }
    }
}
