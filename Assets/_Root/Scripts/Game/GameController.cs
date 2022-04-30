using SnakeGame.Abstractions;
using SnakeGame;
using SnakeGame.Snake;
using SnakeGame.Map;
using SnakeGame.Base;
using SnakeGame.UserControlSystem;
using JoostenProductions;

namespace SnakeGame.Game
{
    public class GameController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private readonly IPlayer player;
        private readonly IMap map;
        private readonly CameraController camera;
        private readonly  UserInputController inputController;

        public GameController(ProfilePlayer profile)
        {
            this.profilePlayer = profile;
            camera = new CameraController();
            player = new SnakeController();
            map = new MapController(profile);
            inputController = new UserInputController(player, map, profile);

            camera.SetCamPos(map.GetNode(5, 5));
            UpdateManager.SubscribeToUpdate(inputController.Update);
        }
    }
}
