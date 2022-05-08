using UnityEngine;
using JoostenProductions;
using SnakeGame.Base;
using SnakeGame.Tools.Reactive;
using SnakeGame.Abstractions;

namespace SnakeGame.UserControlSystem
{
    public class KeyboardInteractionHandler : BaseController, IInteractionHandler
    {
        private readonly IPlayer player;
        private readonly IMap map;
        private bool up, down, left, right;
        private Direction playerDirection = Direction.Right;

        private float rateTime = 0.2f;
        private float timer;

        public KeyboardInteractionHandler(IPlayer player, IMap map)
        {
            this.player = player;
            this.map = map;
            UpdateManager.SubscribeToUpdate(Update);
        }

        public void Update()
        {
            GetInput();
            GetDirection();

            timer += Time.deltaTime;
            if (timer > rateTime)
            {
                timer = 0;
                switch (playerDirection)
                {
                    case Direction.Up:
                        UpdatePlayerPosition(0, 1);
                        break;

                    case Direction.Down:
                        UpdatePlayerPosition(0, -1);
                        break;

                    case Direction.Left:
                        UpdatePlayerPosition(-1, 0);
                        break;

                    case Direction.Right:
                        UpdatePlayerPosition(1, 0);
                        break;
                }
            }
        }

        private void GetDirection()
        {
            if (up)
            {
                if(playerDirection == Direction.Down)
                    return;
                else
                    playerDirection = Direction.Up;
                    
                return;
            }
                
            else if (down)
            {
                if (playerDirection == Direction.Up)
                    return;
                else
                    playerDirection = Direction.Down;

                return;
            }
                
            else if (left)
            {
                playerDirection = Direction.Left;
                return;
            }
                
            else if (right)
            {
                playerDirection = Direction.Right;
                return;
            }
        }
        private void GetInput()
        {
            up = Input.GetButtonDown("Up");
            down = Input.GetButtonDown("Down");
            left = Input.GetButtonDown("Left");
            right = Input.GetButtonDown("Right");
        }

        private void UpdatePlayerPosition(int x, int y)
        {
            INode nextNode = map.GetNode(player.CurrentNode.X + x, player.CurrentNode.Y + y);

            if (nextNode == null)
            {
                Debug.Log("Game Over"); //TODO GameOver
            }
            else
            {
                player.CurrentNode = nextNode;
            }
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
        }

    }
}