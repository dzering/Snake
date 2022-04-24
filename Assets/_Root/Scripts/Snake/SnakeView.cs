using UnityEngine;
using SnakeGame.Base;

namespace SnakeGame.Snake
{
    public class SnakeView : BaseView
    {

        private Color snakeColor;
        public GameObject snakeObj;
        public SnakeView()
        {
            snakeColor = Color.yellow;
            snakeObj = CreateView(snakeColor);
            snakeObj.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        public void UpdateView(Vector3 worldPosition)
        {
            snakeObj.transform.position = worldPosition;
        }
    }
}
