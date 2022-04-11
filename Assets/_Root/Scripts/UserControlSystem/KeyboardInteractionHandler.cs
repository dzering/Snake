using UnityEngine;
using JoostenProductions;
using SnakeGame.Base;
using SnakeGame.Tools.Reactive;
using SnakeGame.Abstractions;

namespace SnakeGame.UserControlSystem
{
    public class KeyboardInteractionHandler : BaseController
    {
        private readonly IPlayerMoveDirection player;
        private bool up, down, left, right;
       
        public KeyboardInteractionHandler(IPlayerMoveDirection player)
        {
            this.player = player;
            UpdateManager.SubscribeToUpdate(SetPlayerDirection);
        }
        private void SetPlayerDirection()
        {
            GetInput();
            if (up)
                player.CurrentDirection = (Direction.Up);
            if (down)
                player.CurrentDirection = (Direction.Down);
            if (left)
                player.CurrentDirection = (Direction.Left);
            if (right)
                player.CurrentDirection = (Direction.Right);

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