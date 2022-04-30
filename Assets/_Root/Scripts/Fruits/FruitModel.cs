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

        public INode Node;

        public FruitModel(INode node)
        {
            Node = node;
        }


    }
}