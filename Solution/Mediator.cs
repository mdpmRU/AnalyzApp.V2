using Business;
using DataContracts.Models;

namespace Solution
{
    public class Mediator : IMediator
    {
        private Dictionary<Guid, Func<List<Analyzer>, List<Analyzer>>> _subscriptions = new();

        public void Raise(List<Analyzer> list)
        {
            foreach (var subscriptionId in _subscriptions.Keys)
                _subscriptions[subscriptionId](list);
        }

        public Guid SubscribeToSubmittedTimeChanged(Func<List<Analyzer>, List<Analyzer>> action)
        {
            var subscriptionId = Guid.NewGuid();
            _subscriptions.Add(subscriptionId, action);
            return subscriptionId;
        }

        public void UnsubscribeFromSubmittedTimeChanged(Guid subscriptionId)
        {
            _subscriptions.Remove(subscriptionId);
        }
    }
}