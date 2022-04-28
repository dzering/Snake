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
using System;

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

        INode playerNode;
        Node nextNode;
        Node fruitNode;

        IFruit fruit;

        public GameController(ProfilePlayer profilePlayer)
        {
            this.profilePlayer = profilePlayer;

            snakeController = new SnakeController();
            AddController(snakeController);

            mapController = new MapController(profilePlayer);
            AddController(mapController);

            interactionHandler = new KeyboardInteractionHandler(snakeController, mapController);
            AddController(interactionHandler);

            cameraController = new CameraController();
            AddController(cameraController);

            Init();

            spawner = new Spawner();
            AddController(spawner);

            // spawn fruit

            fruit = spawner.CreateFruit(EnumFruits.Pear);
            SetFruitPosition(fruit);

            cameraController.SetCamPos(mapController.GetNode(mapController.MaxWidth / 2, mapController.MaxHight / 2).WorldPosition);

        }
        private void Init()
        {
            playerNode = mapController.GetNode(2,2); //TODO make random start position
            snakeController.CurrentNode = playerNode;
        }
        private void SetFruitPosition(IFruit fruit)
        {
            Node node = mapController.GetAvaliableNode();
            fruit.SetPosition(node.WorldPosition);
            fruitNode = node;
            mapController.RemoveNode(fruitNode);
        }
        // private void UpdatePlayerPosition(int x, int y)
        //{
        //    Node prevNode = playerNode;
        //    nextNode = mapController.GetNode(playerNode.X + x, playerNode.Y + y);
        //    snakeController.MoveTail(prevNode);

        //    if(nextNode == null)
        //    {
        //        Debug.Log("Game Over"); //TODO GameOver
        //    }
        //    else
        //    {
        //        bool isScore = false;

        //        if (playerNode == fruitNode)
        //        {
        //            isScore = true;
        //        }

        //        snakeController.CurrentNode = nextNode;
        //        playerNode = nextNode;

        //        //TODO Move Tail;

        //        if (isScore)
        //        {
        //            //TODO If avaliable node == 0, you win;

        //            snakeController.Eating(fruitNode);
        //            mapController.RemoveNode(fruitNode);
        //            SetFruitPosition(fruit);

        //            //TODO You Have Scored;
        //        }
        //    }
        //}
        //protected override void OnDispose()
        //{
        //    snakeController.UnSubscribeOnChange(UpdatePlayerPosition);
        //}
    }
}
