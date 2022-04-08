using UnityEngine;
using JoostenProductions;
using SnakeGame.Base;
using SnakeGame.Tools.Reactive;

namespace SnakeGame.UserControlSystem
{
    public class KeyboardInteractionHandler : BaseController
    {
        SubscriptionProperty<Direction> subscriptionProperty;
        private bool up, down, left, right;
       
        public KeyboardInteractionHandler(SubscriptionProperty<Direction> direction)
        {
            subscriptionProperty = direction;
            UpdateManager.SubscribeToUpdate(SetPlayerDirection);
        }
        private void SetPlayerDirection()
        {
            GetInput();
            if (up)
                subscriptionProperty.Value = Direction.Up;
            if (down)
                subscriptionProperty.Value = Direction.Down;
            if (left)
                subscriptionProperty.Value = Direction.Left;
            if (right)
                subscriptionProperty.Value = Direction.Right;

        }
        private void GetInput()
        {
            up = Input.GetButtonDown("Up");
            down = Input.GetButtonDown("Down");
            left = Input.GetButtonDown("Left");
            right = Input.GetButtonDown("Right");
        }



        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(SetPlayerDirection);
        }
    }
}