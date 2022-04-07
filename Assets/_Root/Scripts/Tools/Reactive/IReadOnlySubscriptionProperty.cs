using System;

namespace SnakeGame.Tools.Reactive
{
    public interface IReadOnlySubscriptionProperty<T>
    {
        T Value { get; }
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnsubscribeOnChange(Action<T> unsubscriptionAction);
    }
}
