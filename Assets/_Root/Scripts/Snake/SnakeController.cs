using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Tools.Reactive;
using SnakeGame.UserControlSystem;
using System;
using SnakeGame.Abstractions;


using JoostenProductions;

namespace SnakeGame.Snake
{
    class SnakeController : BaseController, IPlayerMoveDirection
    {
        public readonly SnakeModel snakeModel;
        private readonly SnakeView snakeView;

        private float rateTime = 0.5f;
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
            snakeModel.OnChangePosition += snakeView.UpdateView;
            UpdateManager.SubscribeToUpdate(MovePlayer);
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
