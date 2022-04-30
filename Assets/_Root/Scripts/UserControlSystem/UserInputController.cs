using UnityEngine;

using SnakeGame.Abstractions;

namespace SnakeGame.UserControlSystem
{
    public class UserInputController : IInteractionHandler
    {
        private readonly IPlayer player;
        private readonly IMap map;
        private readonly ProfilePlayer profilePlayer;

        private Direction direction = Direction.Left;
        private INode nextNode;

        private float time;

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

                player.Move(nextNode);
            }

            time += Time.deltaTime;

        }
        private void SetDirection()
        {
            if (Input.GetButtonDown("Left"))
            {
                direction = Direction.Left;
            }

            else if (Input.GetButtonDown("Right"))
                direction = Direction.Right;

            else if (Input.GetButtonDown("Up"))
                direction = Direction.Up;

            else if (Input.GetButtonDown("Down"))
                direction = Direction.Down;
        }
    }
}
