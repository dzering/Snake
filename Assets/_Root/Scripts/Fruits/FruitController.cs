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
        private FruitModel fruitModel;

        public INode CurrentNode
        {
            get {return fruitModel.Node; }
            set {fruitModel.Node = value; }
        }

        public FruitController() : base()
        {
            view = new FruitView();
            AddGameObject(view.Obj);
            go = view.Obj;
          //  view.Obj.transform.position = node.WorldPosition;
        }
        public void SetPosition(INode node)
        {
            go.transform.position = node.WorldPosition;
        }
    }
}