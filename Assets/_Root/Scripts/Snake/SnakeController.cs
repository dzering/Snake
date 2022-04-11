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

        private Color snakeColor;
        public GameObject snakeObj;

        private float rateTime = 0.2f;
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
            snakeColor = Color.black;
            CreateSnake();
            UpdateManager.SubscribeToUpdate(MovePlayer);
        }

        private void CreateSnake()
        {
            snakeObj = new GameObject("Player");
            SpriteRenderer snakeRenderer = snakeObj.AddComponent<SpriteRenderer>();
            snakeRenderer.sprite = CreateSprite();
            snakeRenderer.sortingOrder = 1;
        }

        private Sprite CreateSprite()
        {
            Texture2D txt = new Texture2D(1,1);
            txt.SetPixel(0, 0, snakeColor);
            txt.Apply();
            txt.filterMode = FilterMode.Point;
            Rect rect = new Rect(0, 0, 1, 1);
            return Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect);

        }

        private void Move()
        {
                switch (currentDirection)
                {
                    case Direction.Up:
                        timer = 0;
                        Y = 1;
                        break;

                    case Direction.Down:
                        timer = 0;
                        Y = -1;
                        break;

                    case Direction.Left:
                        timer = 0;
                        X = -1;
                        break;

                    case Direction.Right:
                        timer = 0;
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
