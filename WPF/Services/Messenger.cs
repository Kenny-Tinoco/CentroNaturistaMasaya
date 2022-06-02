using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace WPF.Services
{
    public class Messenger : IMessenger
    {
        private readonly ConcurrentDictionary<Type, SynchronizedCollection<Subscription>> _subscriptions = new();
        private readonly ConcurrentDictionary<Type, object> _currentState = new();

        public void Send<TypeMessage>(TypeMessage message)
        {
            if (message is null)
                throw new ArgumentException(nameof(message));

            EnsureSubscriptionDictionaryHasMessageType<TypeMessage>();

            var messageType = typeof(TypeMessage);

            _currentState.AddOrUpdate(messageType, (o) => message, (o, old) => message);

            foreach (var subscription in _subscriptions[messageType])
                SendMessageToSubscriber(message, subscription);
        }

        public void Subscribe<TypeMessage>(object subscriber, Action<object> action)
        {
            EnsureSubscriptionDictionaryHasMessageType<TypeMessage>();

            var newSubscriber = new Subscription(subscriber, action);
            var messageType = typeof(TypeMessage);

            _subscriptions[messageType].Add(newSubscriber);

            if (_currentState.ContainsKey(messageType))
                SendMessageToSubscriber(_currentState[messageType], newSubscriber);
        }

        public void Unsubscribe<TypeMessage>(object subscriber)
        {
            var messageType = typeof(TypeMessage);

            if (!_subscriptions.ContainsKey(messageType))
                return;

            var subscription = _subscriptions[messageType].FirstOrDefault(x => x.subscriber == subscriber);

            if (subscription is not null)
                _subscriptions[messageType].Remove(subscription);
        }


        private void EnsureSubscriptionDictionaryHasMessageType<TypeMessage>()
        {
            if (!_subscriptions.ContainsKey(typeof(TypeMessage)))
                _subscriptions.TryAdd(typeof(TypeMessage), new SynchronizedCollection<Subscription>());
        }

        private void SendMessageToSubscriber<TypeMessage>(TypeMessage message, Subscription subscription)
        {
            subscription.action(message);
        }
    }
    public record Subscription(object subscriber, Action<object> action);
}
