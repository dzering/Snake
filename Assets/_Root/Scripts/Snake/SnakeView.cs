using UnityEngine;
using SnakeGame.Base;

namespace SnakeGame.Snake
{
    public class SnakeView : BaseView
    {
        public SnakeView()
        {
            GO = CreateView(Color.yellow);
            GO.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        public void UpdateView(Vector3 worldPosition)
        {
            GO.transform.position = worldPosition;
        }
    }
}
