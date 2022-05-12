using SnakeGame.Base;
using SnakeGame.Game;
using SnakeGame.Profile;
using SnakeGame.UI;
using UnityEngine;


namespace SnakeGame
{
    public class MainController : BaseController
    {
        private readonly ProfilePlayer profilePlayer;
        private readonly Transform placeForUI;
        private GameController gameController;
        private MainMenuController mainMenuController;


        public MainController(ProfilePlayer profilePlayer, Transform placeForUI)
        {
            this.profilePlayer = profilePlayer;
            this.placeForUI = placeForUI;

            OnChangeGameState(profilePlayer.CurrentState.Value);
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);

        }

        private void OnChangeGameState(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.None:
                    break;
                case GameState.Menu:
                    mainMenuController = new MainMenuController(profilePlayer, placeForUI);
                    gameController?.Dispose();
                    break;
                case GameState.Game:
                    gameController = new GameController(profilePlayer);
                    mainMenuController?.Dispose();
                    break;
                default:
                    break;
            }
        }

        protected override void OnDispose()
        {
            profilePlayer.CurrentState.UnsubscribeOnChange(OnChangeGameState);
            base.OnDispose();
        }
    }
}