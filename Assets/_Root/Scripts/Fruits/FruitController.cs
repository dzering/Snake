using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Base;
using System;
using SnakeGame.Tools.ResourceManager;
using Object = UnityEngine.Object;
using SnakeGame.Map;
using SnakeGame.Abstractions;

namespace SnakeGame.Content.Fruits
{
    public class FruitController : BaseController, IFruit
    {
        private readonly GameObject go;
        private readonly BaseView view;

        public FruitController()
        {
            view = new FruitView();
            AddGameObject(view.Obj);
            go = view.Obj;
        }

        public FruitController(Vector3 worldPosition) : base()
        {
            view.Obj.transform.position = worldPosition;
        }
        public void SetPosition(Vector3 position)
        {
            go.transform.position = position;
        }
    }
}