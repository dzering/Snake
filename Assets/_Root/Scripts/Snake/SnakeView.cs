using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Utility;
using SnakeGame.Abstractions;

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

        public void UpdateView(INode node)
        {
            Utilities.PlaceObjectCorrect(Obj, node.WorldPosition);
        }
    }
}
