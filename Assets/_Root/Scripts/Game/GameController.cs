using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Snake;
using SnakeGame.Map;
using SnakeGame.UserControlSystem;
using SnakeGame.Tools.Reactive;
using SnakeGame.Camera;
using SnakeGame;
using SnakeGame.Content.Fruits;
using SnakeGame.Abstractions;

namespace SnakeGame.Game
{
    public class GameController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private readonly MapController mapController;
        private readonly KeyboardInteractionHandler interactionHandler;
        private readonly SnakeController snakeController;
        private readonly CameraController cameraController;
        private readonly Spawner spawner;


        Node playerNode;
        Node targetNode;

        public GameController(ProfilePlayer profilePlayer)
        {
            this.profilePlayer = profilePlayer;

            snakeController = new SnakeController();
            AddController(snakeController);

            interactionHandler = new KeyboardInteractionHandler(snakeController);
            AddController(interactionHandler);

            mapController = new MapController(profilePlayer);
            AddController(mapController);

            cameraController = new CameraController();
            AddController(cameraController);

            Init();

            spawner = new Spawner();
            AddController(spawner);
            spawner.CreateFruit(EnumFruits.Pear).SetPosition(profilePlayer.MapModel.GetFreePosition());

            cameraController.SetCamPos(profilePlayer.MapModel.GetNode(mapController.MaxWidth / 2, mapController.MaxHight / 2).worldPosition);

        }

        private void Init()
        {
            playerNode = profilePlayer.MapModel.GetNode(2,2); //TODO make random start position
            snakeController.snakeModel.SnakeWorldPosition = playerNode.worldPosition;
            snakeController.snakeModel.OnChangeMove += UpdatePlayerPosition;
        }

        private void UpdatePlayerPosition(int x, int y)
        {
            targetNode = profilePlayer.MapModel.GetNode(playerNode.X + x, playerNode.Y + y);
            if(targetNode == null)
            {
                Debug.Log("Game Over"); // GameOver
            }
            else
            {
                snakeController.snakeModel.SnakeWorldPosition = targetNode.worldPosition;
                playerNode = targetNode;
            }
        }

        protected override void OnDispose()
        {
            snakeController.snakeModel.OnChangeMove -= UpdatePlayerPosition;
        }
    }
}
