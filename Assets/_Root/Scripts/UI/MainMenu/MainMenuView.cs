using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SnakeGame.UI
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button startButton;

        public void Init(UnityAction startGame)
        {
            startButton.onClick.AddListener(startGame);
        }

        private void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();
        }
    }
}