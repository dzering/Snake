using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Tools.Reactive;
using SnakeGame.UserControlSystem;
using System;
using SnakeGame.Abstractions;


using JoostenProductions;

namespace SnakeGame.Snake
{
    class SnakeController : BaseController, IPlayerMove
    {
        public Action<int, int> OnMove;

        private Color snakeColor;
        public GameObject snakeObj;
        IReadOnlySubscriptionProperty<Direction> moveDirection;

        private Direction currentDirection = Direction.Right;

        private float rateTime = 0.5f;
        private float timer;

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


        public SnakeController(IReadOnlySubscriptionProperty<Direction> moveDirection)
        {
            this.moveDirection = moveDirection;
            snakeColor = Color.black;
            CreateSnake();
            moveDirection.SubscribeOnChange(Move);
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

        public void Move(Direction direction)
        {
                switch (direction)
                {
                    case Direction.Up:
                        timer = 0;
                        Y = 1;
                        currentDirection = direction;
                        break;

                    case Direction.Down:
                        timer = 0;
                        Y = -1;
                        currentDirection = direction;
                        break;

                    case Direction.Left:
                        timer = 0;
                        X = -1;
                        currentDirection = direction;
                        break;

                    case Direction.Right:
                        timer = 0;
                        X = 1;
                        currentDirection = direction;
                        break;
                }
        }

        private void MovePlayer()
        {
            timer += Time.deltaTime;
            if(timer > rateTime)
            {
                timer = 0;
                Move(currentDirection);
            }
        }

        protected override void OnDispose()
        {
            moveDirection.UnsubscribeOnChange(Move);
            UpdateManager.UnsubscribeFromUpdate(MovePlayer);
        }

        
        


    }
}
