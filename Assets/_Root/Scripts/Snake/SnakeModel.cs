using System;
using UnityEngine;
using SnakeGame.Abstractions;

namespace SnakeGame
{
    public class SnakeModel
    {
        public Action<INode> OnChangePosition;
        private INode currentNode;
        public INode CurrentNode
        {
            get { return currentNode; }
            set
            {
                currentNode = value;
                OnChangePosition?.Invoke(currentNode);                
            }
        }
    }
}