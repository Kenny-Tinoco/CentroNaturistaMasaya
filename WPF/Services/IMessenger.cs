using System;

namespace WPF.Services
{
    public interface IMessenger
    {
        void Send<TypeMessage>(TypeMessage message);
        void Subscribe<TypeMessage>(object subscriber, Action<object> action);
        void Unsubscribe<TypeMessage>(object subscriber);
    }
}
