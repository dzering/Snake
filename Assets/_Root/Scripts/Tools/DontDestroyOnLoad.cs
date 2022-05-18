using UnityEngine;

namespace SnakeGame.Tools
{
    internal class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            if(enabled)
                DontDestroyOnLoad(gameObject);
        }
    }
}
