
namespace DeveloperEvaluation.Domain.Services
{
    public interface IEventPublisher
    {
        void PublishEvent(string eventMessage, string queueName);
    }
}

