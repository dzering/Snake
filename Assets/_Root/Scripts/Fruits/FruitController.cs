using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Content.Fruits;
using System;
using SnakeGame.Tools.ResourceManager;
using Object = UnityEngine.Object;

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
        GameObject pref = ResourceLoader.LoadPrefab(path);
        GameObject go = Object.Instantiate(pref);
        return go.GetComponent<FruitView>();
    }
}
