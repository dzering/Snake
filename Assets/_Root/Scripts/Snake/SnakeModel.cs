using System;
using UnityEngine;
using SnakeGame.Abstractions;

namespace SnakeGame
{
    public class SnakeModel
    {
        public Action<Vector3> OnChangePosition;
        private INode currentNode;
        public INode CurrentNode
        {
            get { return currentNode; }
            set
            {
                currentNode = value;
                OnChangePosition(currentNode.WorldPosition);                
            }
        }
    }
}