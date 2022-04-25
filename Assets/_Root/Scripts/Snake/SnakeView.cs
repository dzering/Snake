using UnityEngine;
using SnakeGame.Base;

namespace SnakeGame.Snake
{
    public class SnakeView : BaseView
    {
        public SnakeView()
        {
            Obj = CreateView(Color.yellow);
            Obj.name = "SnakeHead";
            Obj.GetComponent<SpriteRenderer>().sortingOrder = 2;
        }

        public void UpdateView(Vector3 worldPosition)
        {
            Obj.transform.position = worldPosition;
        }
    }
}
