using UnityEngine;
using SnakeGame.Abstractions;
using SnakeGame.Snake;
using SnakeGame.Map;
using SnakeGame.Base;
using SnakeGame.UserControlSystem;
using JoostenProductions;
using SnakeGame.Content;
using System.Collections.Generic;

namespace SnakeGame.Game
{
    public class GameController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private readonly IPlayer player;
        private readonly IMap map;
        private readonly CameraController camera;
        private readonly  UserInputController inputController;
        private readonly Spawner spawner;

        private readonly List<IFruit> fruits;

        public GameController(ProfilePlayer profile)
        {
            this.profilePlayer = profile;
            camera = new CameraController();
            player = new SnakeController();
            map = new MapController(profile);
            inputController = new UserInputController(player, map, profile);
            spawner = new Spawner();

            player.CurrentNode = map.GetNode(3, 3);

            fruits = new List<IFruit>();

            IFruit apple = spawner.CreateFruit(EnumFruits.Apple);
            apple.CurrentNode = map.GetAvaliableNode();
            fruits.Add(apple);
            

            camera.SetCamPos(map.GetCenterMap());

            UpdateManager.SubscribeToUpdate(Update);
        }

        private void Update()
        {
            inputController.Update();
            EatController();
        }

        private void EatController()
        {
            bool isScore = false;
            foreach (var fruit in fruits)
            {
                if(player.CurrentNode == fruit.CurrentNode)
                {
                    isScore = true;
                    fruit.CurrentNode = map.GetAvaliableNode();
                }
            }

            if (isScore)
            {
                Debug.Log("Score");
            }
        }
    }
}
