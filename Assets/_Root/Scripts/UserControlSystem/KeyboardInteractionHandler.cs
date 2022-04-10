using UnityEngine;
using JoostenProductions;
using SnakeGame.Base;
using SnakeGame.Tools.Reactive;
using SnakeGame.Abstractions;

namespace SnakeGame.UserControlSystem
{
    public class KeyboardInteractionHandler : BaseController
    {
        private readonly IPlayerMove player;
        private bool up, down, left, right;
       
        public KeyboardInteractionHandler(IPlayerMove player)
        {
            this.player = player;
            UpdateManager.SubscribeToUpdate(SetPlayerDirection);
        }
        private void SetPlayerDirection()
        {
            GetInput();
            if (up)
                player.Move(Direction.Up);
            if (down)
                player.Move(Direction.Down);
            if (left)
                player.Move(Direction.Left);
            if (right)
                player.Move(Direction.Right);

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