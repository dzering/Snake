using SnakeGame.Base;
using SnakeGame.Game;


namespace SnakeGame
{
    public class MainController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private readonly GameController gameController;


        public MainController(ProfilePlayer profilePlayer)
        {
            this.profilePlayer = profilePlayer;
            gameController = new GameController(profilePlayer);
            AddController(gameController);
        }
    }
}