using System;

namespace SnakeGame.Tools.Reactive
{
    public class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
    {
        private T value;
        public Action<T> OnChangeValue;

        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnChangeValue?.Invoke(this.value);
            }
        }

        public void SubscribeOnChange(Action<T> subscriptionAction)
        {
            OnChangeValue += subscriptionAction;
        }

        public void UnsubscribeOnChange(Action<T> unsubscriptionAction)
        {
            OnChangeValue -= unsubscriptionAction;
        }
    }
}
