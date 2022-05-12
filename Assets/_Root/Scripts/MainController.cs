using SnakeGame.Base;
using SnakeGame.Game;
using SnakeGame.Profile;


namespace SnakeGame
{
    public class MainController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private GameController gameController;


        public MainController(ProfilePlayer profilePlayer)
        {
            this.profilePlayer = profilePlayer;

        }

        private void OnChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.None:
                    break;
                case GameState.Menu:
                    break;
                case GameState.Game:
                    gameController = new GameController(profilePlayer);
                    break;
                default:
                    break;
            }
        }
    }
}