using DeveloperEvaluation.Domain.Events;
using DeveloperEvaluation.Domain.Services;
using Newtonsoft.Json;

namespace DeveloperEvaluation.Application.Event
{
    public class EventService
    {
        private readonly IEventPublisher _eventPublisher;

        public EventService(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public void PublishEvent(string message)
        {
            _eventPublisher.PublishEvent(message,"allow");
        }

        public void PublishSaleCreatedEvent(SaleCreatedEvent saleCreatedEvent)
        {
            _eventPublisher.PublishEvent(JsonConvert.SerializeObject(saleCreatedEvent),"SaleCreated");
        }

        public void PublishSaleModifiedEvent(SaleModifiedEvent saleModifiedEvent)
        {
            _eventPublisher.PublishEvent(JsonConvert.SerializeObject(saleModifiedEvent), "SaleModified");
        }

        public void PublishSaleCancelledEvent(SaleCancelledEvent saleModifiedEvent)
        {
            _eventPublisher.PublishEvent(JsonConvert.SerializeObject(saleModifiedEvent), "SaleCancelled");
        }
    }
}
