using UnityEngine;
using SnakeGame.Game;
using SnakeGame.Profile;
using SnakeGame.Camera;



namespace SnakeGame
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Transform placeForUI;

        private MainController mainController;
        private ProfilePlayer profilePlayer;

        
        void Start()
        {
            profilePlayer = new ProfilePlayer();
            mainController = new MainController(profilePlayer, placeForUI);
            profilePlayer.CurrentState.Value = GameState.Menu;
        }

        private void OnDestroy()
        {
            mainController?.Dispose();
        }

    }
}