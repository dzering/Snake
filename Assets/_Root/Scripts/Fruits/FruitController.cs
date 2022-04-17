using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Base;
using System;
using SnakeGame.Tools.ResourceManager;
using Object = UnityEngine.Object;
using SnakeGame.Map;

namespace SnakeGame.Content.Fruits
{
    public class FruitController : BaseController
    {
        //TODO: refactoring

        //private FruitView fruit;
        //private ResourcePath path = new ResourcePath() { Path = "Prefabs/Fruit" };

        private FruitView view;

        public FruitController(Vector3 worldPosition)
        {
            view = new FruitView();
            view.GO.transform.position = worldPosition;

            //fruit = LoadView();
        }

        //private FruitView LoadView()
        //{
        //    GameObject pref = ResourceLoader.LoadPrefab(path);
        //    GameObject go = Object.Instantiate(pref);
        //    return go.GetComponent<FruitView>();
        //}
    }
}