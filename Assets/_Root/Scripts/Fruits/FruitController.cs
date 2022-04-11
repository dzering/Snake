using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Content.Fruits;
using System;
using SnakeGame.Tools.ResourceManager;

public class FruitController : BaseController
{
    private FruitView fruit;
    private ResourcePath path = new ResourcePath() { Path = "Prefabs/Fruit" };

    public FruitController()
    {
        fruit = LoadView();
    }

    private FruitView LoadView()
    {
        throw new NotImplementedException();
    }
}
