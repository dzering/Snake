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
                playerDirection = Direction.Up;
                return;
            }
                
            if (down)
            {
                playerDirection = Direction.Down;
                return;
            }
                
            if (left)
            {
                playerDirection = Direction.Left;
                return;
            }
                
            if (right)
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
           // snakeController.MoveTail(prevNode);

            if (nextNode == null)
            {
                Debug.Log("Game Over"); //TODO GameOver
            }
            else
            {
                //bool isScore = false;

                //if (playerNode == fruitNode)
                //{
                //    isScore = true;
                //}

                player.CurrentNode = nextNode;
                //playerNode = nextNode;

                //TODO Move Tail;

                //if (isScore)
                //{
                //    //TODO If avaliable node == 0, you win;

                //    snakeController.Eating(fruitNode);
                //    mapController.RemoveNode(fruitNode);
                //    SetFruitPosition(fruit);

                    //TODO You Have Scored;
                //}
            }
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
        }

    }
}