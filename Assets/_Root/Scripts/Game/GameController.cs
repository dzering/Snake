using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Snake;
using SnakeGame.Map;
using SnakeGame.UserControlSystem;
using SnakeGame.Tools.Reactive;

namespace SnakeGame.Game
{
    public class GameController : BaseController
    {
        private MapController mapController;
        private KeyboardInteractionHandler interactionHandler;
        private SnakeController snakeController;

        private SubscriptionProperty<Direction> direction;

        Node playerNode;
        Node targetNode;

        public GameController()
        {
            Init();
        }

        private void Init()
        {
            direction = new SubscriptionProperty<Direction>();
            interactionHandler = new KeyboardInteractionHandler(direction);
            mapController = new MapController();
            playerNode = mapController.GetNode(2, 2); //TODO make random start position
            snakeController = new SnakeController(direction);
            snakeController.snakeObj.transform.position = playerNode.worldPosition;

            AddController(mapController);
            AddController(snakeController);
            snakeController.OnMove += UpdatePlayerPosition;
        }

        private void UpdatePlayerPosition(int x, int y)
        {
            targetNode = mapController.GetNode(playerNode.X + x, playerNode.Y + y);
            if(targetNode == null)
            {
                Debug.Log("Game Over"); // GameOver
            }
            else
            {
                snakeController.snakeObj.transform.position = targetNode.worldPosition;
                playerNode = targetNode;
            }
        }


    }
}
