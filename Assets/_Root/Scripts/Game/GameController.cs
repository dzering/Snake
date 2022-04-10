﻿using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Snake;
using SnakeGame.Map;
using SnakeGame.UserControlSystem;
using SnakeGame.Tools.Reactive;
using SnakeGame.Camera;
using SnakeGame;

namespace SnakeGame.Game
{
    public class GameController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private readonly MapController mapController;
        private readonly KeyboardInteractionHandler interactionHandler;
        private readonly SnakeController snakeController;
        private readonly CameraController cameraController;


        private SubscriptionProperty<Direction> direction;

        Node playerNode;
        Node targetNode;

        public GameController(ProfilePlayer profilePlayer)
        {
            this.profilePlayer = profilePlayer;
            direction = new SubscriptionProperty<Direction>();

            snakeController = new SnakeController(direction);
            AddController(snakeController);

            interactionHandler = new KeyboardInteractionHandler(snakeController);
            AddController(interactionHandler);

            mapController = new MapController(profilePlayer);
            AddController(mapController);

            cameraController = new CameraController();
            AddController(cameraController);

            Init();

            cameraController.SetCamPos(mapController.GetNode(mapController.MaxWidth / 2, mapController.MaxHight / 2).worldPosition);

        }

        private void Init()
        {
            playerNode = mapController.GetNode(2, 2); //TODO make random start position
            
            snakeController.snakeObj.transform.position = playerNode.worldPosition;

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

        protected override void OnDispose()
        {
            snakeController.OnMove -= UpdatePlayerPosition;
        }


    }
}
