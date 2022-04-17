using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Map;
using System;

namespace SnakeGame.Content.Fruits
{
    public class FruitModel
    {
        public Action<Vector3> OnUpdate;

        private Node node;

        public FruitModel(Node node)
        {
            this.node = node;
        }


    }
}