using UnityEngine;

namespace SnakeGame.UserControlSystem
{
    public class KeyboardInteractionHandler : MonoBehaviour
    {


        private bool up, down, left, right;

        // Update is called once per frame
        void Update()
        {

        }

        private void GetInput()
        {
            up = Input.GetButtonDown("Up");
            down = Input.GetButtonDown("Up");
            left = Input.GetButtonDown("Up");
            right = Input.GetButtonDown("Up");
        }
    }
}