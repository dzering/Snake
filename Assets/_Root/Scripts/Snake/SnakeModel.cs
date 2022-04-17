using System;
using UnityEngine;

namespace SnakeGame
{
    public class SnakeModel
    {
        public Action<int, int> OnChange;
        private int x;
        private int y;

        public int X { get => x; 
            set 
            {
                    x = value;
                    OnChange?.Invoke(x, default);
            }
        }
        public int Y
        {
            get => y;
            set
            {
                y = value;
                OnChange?.Invoke(default, y);
            }
        }
    }
}