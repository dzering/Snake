using UnityEngine;
using SnakeGame.Abstractions;
using SnakeGame.Snake;
using SnakeGame.Map;
using SnakeGame.Base;
using SnakeGame.UserControlSystem;
using JoostenProductions;
using SnakeGame.Profile;
using System.Collections.Generic;

namespace SnakeGame.Game
{
    public class GameController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private readonly SnakeController player;
        private readonly MapController map;
       // private readonly CameraController camera;
        private readonly UserInputController inputController;
        private readonly FruitSpawner fruitSpawner;

        private readonly List<IFruit> fruits;

        public GameController(ProfilePlayer profile)
        {
            this.profilePlayer = profile;

            //camera = new CameraController();
            //AddController(camera);

            player = new SnakeController();
            AddController(player);

            map = new MapController(profile);
            AddController(map);

            inputController = new UserInputController(player, map, profile);
            AddController(inputController);

            fruitSpawner = new FruitSpawner();
            AddController(fruitSpawner);

            fruits = new List<IFruit>();

            Init();
        }


        private void Init()
        {
            player.CurrentNode = map.GetNode(3, 3);
            IFruit apple = fruitSpawner.CreateFruit(EnumFruits.Apple);
            apple.CurrentNode = map.GetAvaliableNode();
            fruits.Add(apple);
            map.RemoveNodeFromAvaliable(apple.CurrentNode);

         //   camera.SetCamPos(map.GetCenterMap());

            UpdateManager.SubscribeToUpdate(Update);
            player.OnMove += CheckTailIntersection;
            player.OnMove += Score;
            player.OnTailLastNode += map.AddNodeToAvaliable;
        }

        private void Update()
        {
            inputController.Update();
        }

        private void CheckTailIntersection(INode playerNode)
        {
            foreach (var item in player.Tail)
            {
                if (item.Node == playerNode)
                    Debug.Log("Game over! Ate his tail.");
            }
        }

        private void Score(INode playerNode)
        {
            bool isScore = false;
            foreach (var fruit in fruits)
            {
                if(playerNode == fruit.CurrentNode)
                {
                    player.Eat(fruit.CurrentNode);
                    
                    isScore = true;

                    INode nextNode = map.GetAvaliableNode();
                    map.RemoveNodeFromAvaliable(nextNode);
                    fruit.CurrentNode = nextNode;
                }
            }

            if (isScore)
            {
                Debug.Log("Score");
            }
        }
        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(Update);
            player.OnMove -= CheckTailIntersection;
            player.OnMove -= Score;
            player.OnTailLastNode -= map.RemoveNodeFromAvaliable;
            fruits.Clear();
        }
    }
}
