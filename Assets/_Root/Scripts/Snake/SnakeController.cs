using UnityEngine;
using SnakeGame.Base;
using SnakeGame.UserControlSystem;
using SnakeGame.Abstractions;
using JoostenProductions;
using System.Collections.Generic;
using SnakeGame.Map;
using System;

namespace SnakeGame.Snake
{
    class SnakeController : BaseController, IPlayer
    {
        private readonly SnakeModel snakeModel;
        private readonly SnakeView snakeView;
        private readonly List<TailNodeView> tail;
        private GameObject tailParant;
        private Direction currentDirection = Direction.Right;
        public SnakeController()
        {
            snakeModel = new SnakeModel();
            snakeView = new SnakeView();
            tail = new List<TailNodeView>();
            tailParant = new GameObject("Snake");

            snakeModel.OnChangePosition += snakeView.UpdateView;
        }
        public Direction CurrentDirection {
            get { return currentDirection; }
            set 
            {
                    currentDirection = value; 
            }
        }
        public INode CurrentNode { 
            get 
            {
                return snakeModel.CurrentNode;
            }
            set 
            {
                snakeModel.CurrentNode = value;
            }
        }
        public void Move(INode nextNode)
        {
            CurrentNode = nextNode;
        }
        public void Eating(INode node)
        {
            TailNodeView tailNode = new TailNodeView();
            tail.Add(tailNode);
            tailNode.Node = node;
            tailNode.Obj.name = nameof(tailNode);
            tailNode.Obj.transform.parent = tailParant.transform;
            tailNode.Obj.transform.position = node.WorldPosition;
        }

        public void MoveTail(INode prevNode)
        {
            if (tail.Count == 0)
                return;

            INode prev = prevNode;
            for (int i = 0; i < tail.Count; i++)
            {
                INode tempNode = tail[i].Node;

                tail[i].Node = prev;
                prev = tempNode;
                tail[i].Obj.transform.position = tail[i].Node.WorldPosition;
            }
        }

        protected override void OnDispose()
        {
            snakeModel.OnChangePosition -= snakeView.UpdateView;
        }

    }
}
