using System.Collections;
using System.Collections.Generic;
using SnakeGame.Abstractions;
using UnityEngine;
using SnakeGame.Map;
using System;

namespace SnakeGame.Content.Fruits
{
    public class FruitModel
    {
        public Action<Vector3> OnUpdate;
        private INode node;

        public INode Node
        {
            get {return node; }
            set {
                node = value;
                if(node!= null)
                    OnUpdate?.Invoke(node.WorldPosition);
            }
        }
    }
}