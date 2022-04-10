using UnityEngine;
using SnakeGame.Game;


namespace SnakeGame
{
    public class Root : MonoBehaviour
    {
        private MainController mainController;
        private ProfilePlayer profilePlayer;
        
        void Start()
        {
            profilePlayer = new ProfilePlayer();
            mainController = new MainController(profilePlayer);
        }

        private void OnDestroy()
        {
            mainController?.Dispose();
        }

    }
}