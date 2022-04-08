using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Tools.Reactive;
using SnakeGame.UserControlSystem;
using System;

namespace SnakeGame.Snake
{
    class SnakeController : BaseController
    {
        public Action<int, int> OnMove;

        private Color snakeColor;
        public GameObject snakeObj;
        IReadOnlySubscriptionProperty<Direction> moveDirection;

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
            moveDirection.SubscribeOnChange(MovePlayer);
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
            return Sprite.Create(txt, rect, Vector2.one * 0.5f, 1, 0, SpriteMeshType.FullRect);

        }

        private void MovePlayer(Direction direction)
        {

            switch (direction)
            {
                case Direction.Up:
                    Y = 1;
                    break;
                case Direction.Down:
                    Y = -1;
                    break;
                case Direction.Left:
                    X = -1;
                    break;
                case Direction.Right:
                    X = 1;
                    break;
            }
        }

        protected override void OnDispose()
        {
            moveDirection.UnsubscribeOnChange(MovePlayer);
        }
    }
}
