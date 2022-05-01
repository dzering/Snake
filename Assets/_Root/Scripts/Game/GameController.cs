using UnityEngine;
using SnakeGame.Abstractions;
using SnakeGame.Snake;
using SnakeGame.Map;
using SnakeGame.Base;
using SnakeGame.UserControlSystem;
using JoostenProductions;
using SnakeGame.Content;

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

        public GameController(ProfilePlayer profile)
        {
            this.profilePlayer = profile;
            camera = new CameraController();
            player = new SnakeController();
            map = new MapController(profile);
            inputController = new UserInputController(player, map, profile);
            spawner = new Spawner();

            player.CurrentNode = map.GetNode(3, 3);

            spawner.CreateFruit(EnumFruits.Apple).CurrentNode = map.GetNode(5,5);



            camera.SetCamPos(map.GetCenterMap());

            UpdateManager.SubscribeToUpdate(inputController.Update);
        }
    }
}
