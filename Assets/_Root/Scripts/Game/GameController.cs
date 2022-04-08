using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Snake;
using SnakeGame.Map;
using SnakeGame.UserControlSystem;
using SnakeGame;

namespace SnakeGame.Game
{
    public class GameController : BaseController
    {
        private MapController mapController;
        private KeyboardInteractionHandler interactionHandler;
        private SnakeController snakeController;

        Node startPosition;

        public GameController()
        {
            mapController = new MapController();
            startPosition = mapController.GetNode(2, 2); //TODO make random start position
            snakeController = new SnakeController();
            snakeController.snakeObj.transform.position = startPosition.worldPosition;

        }

    }
}
