using UnityEngine;

using SnakeGame.Abstractions;

namespace SnakeGame.UserControlSystem
{
    public class UserInputController : IInteractionHandler
    {
        private readonly IPlayer player;
        private readonly IMap map;
        private readonly ProfilePlayer profilePlayer;

        private Direction direction = Direction.Right;
        private INode nextNode;

        private float time;

        private INode prevNode;

        public UserInputController(IPlayer player, IMap map, ProfilePlayer profilePlayer)
        {
            this.player = player;
            this.map = map;
            this.profilePlayer = profilePlayer;
        }

        public void Update()
        {
            SetDirection();
            
            if (time > profilePlayer.Speed )
            {
                time = 0;
                switch (direction)
                {
                    case Direction.Left:
                        nextNode = map.GetNode(player.CurrentNode.X - 1, player.CurrentNode.Y);
                        break;

                    case Direction.Right:
                        nextNode = map.GetNode(player.CurrentNode.X + 1, player.CurrentNode.Y);
                        break;

                    case Direction.Up:
                        nextNode = map.GetNode(player.CurrentNode.X, player.CurrentNode.Y + 1);
                        break;

                    case Direction.Down:
                        nextNode = map.GetNode(player.CurrentNode.X, player.CurrentNode.Y - 1);
                        break;
                }

                if (nextNode != null)
                {
                    prevNode = player.CurrentNode;
                    player.Move(nextNode);
                }
                else
                {
                    Debug.Log("Game Over");
                }
            }

            time += Time.deltaTime;

        }

        private void SetDirection()
        {
            if (Input.GetButtonDown("Left"))
            {
                nextNode = map.GetNode(player.CurrentNode.X - 1, player.CurrentNode.Y); //TODO optimization possibility
                if (nextNode == prevNode)
                    direction = Direction.Right;
                else
                    direction = Direction.Left;
            }

            else if (Input.GetButtonDown("Right"))
            {
                nextNode = map.GetNode(player.CurrentNode.X + 1, player.CurrentNode.Y);
                if (nextNode == prevNode)
                    direction = Direction.Left;
                else
                    direction = Direction.Right;
            }

            else if (Input.GetButtonDown("Up"))
            {
                nextNode = map.GetNode(player.CurrentNode.X, player.CurrentNode.Y + 1);
                if (nextNode == prevNode)
                    direction = Direction.Down;
                else
                    direction = Direction.Up;
            }

            else if (Input.GetButtonDown("Down"))
            {
                nextNode = map.GetNode(player.CurrentNode.X, player.CurrentNode.Y - 1);
                if (nextNode == prevNode)
                    direction = Direction.Up;
                else
                    direction = Direction.Down;
            }
        }
    }
}
