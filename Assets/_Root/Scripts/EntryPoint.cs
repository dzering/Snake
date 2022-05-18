using UnityEngine;
using SnakeGame.Services.Analitics;

using SnakeGame.Profile;



namespace SnakeGame
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform placeForUI;
        [SerializeField] private AnaliticsManager analiticsManager;

        private MainController mainController;
        private ProfilePlayer profilePlayer;

        
        void Start()
        {
            profilePlayer = new ProfilePlayer();
            mainController = new MainController(profilePlayer, placeForUI);
            profilePlayer.CurrentState.Value = GameState.Menu;

            analiticsManager.GameLaunched();
        }

        private void OnDestroy()
        {
            mainController?.Dispose();
        }

    }
}