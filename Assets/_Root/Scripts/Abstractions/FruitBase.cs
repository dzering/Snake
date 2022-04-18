using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Content.Fruits;
using SnakeGame.Base;

public abstract class FruitBase : BaseController
{
    public static void CreateFruit(Vector3 position)
    {
        new FruitController(position);
            
    }
}
