using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Tools.Reactive;
using SnakeGame.UserControlSystem;
using System;
using SnakeGame.Abstractions;


using JoostenProductions;
using System.Collections.Generic;
using SnakeGame.Map;

namespace SnakeGame.Snake
{
    class SnakeController : BaseController, IPlayerMoveDirection
    {
        public readonly SnakeModel snakeModel;
        private readonly SnakeView snakeView;
        private readonly List<TailNodeView> tail;
       

        private float rateTime = 0.2f;
        private float timer;

        private Direction currentDirection = Direction.Right;

        public Direction CurrentDirection {
            get { return currentDirection; }
            set 
            {
                    currentDirection = value; 
            }
        }

        public SnakeController()
        {
            snakeModel = new SnakeModel();
            snakeView = new SnakeView();
            tail = new List<TailNodeView>();
            snakeModel.OnChangePosition += snakeView.UpdateView;
            UpdateManager.SubscribeToUpdate(MovePlayer);
        }

        public void Eating(Node node)
        {
            TailNodeView tailNode = new TailNodeView();
            tail.Add(tailNode);
            tailNode.Node = node;
            tailNode.GO.transform.position = node.worldPosition;
        }

        public void MoveTail(Node prevNode)
        {
            if (tail.Count == 0)
                return;

            Node prev = prevNode;
            for (int i = 0; i < tail.Count; i++)
            {
                Node tempNode = tail[i].Node;

                tail[i].Node = prev;
                prev = tempNode;
                tail[i].GO.transform.position = tail[i].Node.worldPosition;
            }
        }

        private void Move()
        {
                switch (currentDirection)
                {
                    case Direction.Up:
                        snakeModel.Y = 1;
                        break;

                    case Direction.Down:
                        snakeModel.Y = -1;
                        break;

                    case Direction.Left:
                        snakeModel.X = -1;
                        break;

                    case Direction.Right:
                        snakeModel.X = 1;
                        break;
                }
        }

        private void MovePlayer()
        {
            timer += Time.deltaTime;
            if(timer > rateTime)
            {
                timer = 0;
                Move();
            }
        }

        protected override void OnDispose()
        {
            UpdateManager.UnsubscribeFromUpdate(MovePlayer);
            snakeModel.OnChangePosition -= snakeView.UpdateView;
        }

    }
}
