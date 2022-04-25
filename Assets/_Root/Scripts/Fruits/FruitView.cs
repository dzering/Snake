using UnityEngine;
using SnakeGame.Base;


namespace SnakeGame.Content.Fruits
{
    public class FruitView : BaseView
    {
        public FruitView()
        {
            Obj = CreateView(Color.red);
        }

    }
}