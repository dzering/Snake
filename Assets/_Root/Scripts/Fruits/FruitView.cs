using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Abstractions;
using SnakeGame.Utility;


namespace SnakeGame.Content.Fruits
{
    public class FruitView : BaseView
    {
        public FruitView()
        {
            Obj = CreateView(Color.red);
        }

        public void UpdatePosition(Vector3 position)
        {
            //Obj.transform.position = position;
            Utilities.PlaceObjectCorrect(Obj, position);
        }

    }
}