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
        public Action<int, int> OnMove;
        public GameObject snakeObj;

        private float rateTime = 0.5f;
        private float timer;

        private Direction currentDirection = Direction.Right;

        public int X {
            set 
            {
                if(OnMove != null)
                {
                    OnMove?.Invoke(value, default);
                }
            } 
        }
        public int Y {
            set
            {
                if (OnMove != null)
                {
                    OnMove?.Invoke(default, value);
                }
            }
        }

        public Direction CurrentDirection {
            get { return currentDirection; }
            set 
            {
                    currentDirection = value; 
            }
        }

        public SnakeController()
        {
            snakeObj = new SnakeView().snakeObj;
            UpdateManager.SubscribeToUpdate(MovePlayer);
        }

        private void Move()
        {
                switch (currentDirection)
                {
                    case Direction.Up:
                       // timer = 0;
                        Y = 1;
                        break;

                    case Direction.Down:
                       // timer = 0;
                        Y = -1;
                        break;

                    case Direction.Left:
                       // timer = 0;
                        X = -1;
                        break;

                    case Direction.Right:
                       // timer = 0;
                        X = 1;
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
        }

    }
}
