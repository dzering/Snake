using System;
using UnityEngine;

namespace SnakeGame
{
    public class SnakeModel
    {
        public Action<int, int> OnChangeMove;
        public Action<Vector3> OnChangePosition;
        private int x;
        private int y;
        private Vector3 snakeWorldPosition;

        public int X { get => x; 
            set 
            {
                    x = value;
                    OnChangeMove?.Invoke(x, default);
            }
        }
        public int Y
        {
            get => y;
            set
            {
                y = value;
                OnChangeMove?.Invoke(default, y);
            }
        }

        public Vector3 SnakeWorldPosition
        {
            get => snakeWorldPosition;
            set
            {
                snakeWorldPosition = value;
                OnChangePosition(snakeWorldPosition);                
            }
        }
    }
}