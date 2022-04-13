using UnityEngine;

namespace SnakeGame.Snake
{
    public class SnakeView
    {

        private Color snakeColor;
        public GameObject snakeObj;
        public SnakeView()
        {
            snakeColor = Color.yellow;
            CreateSnake();

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
            Texture2D txt = new Texture2D(1, 1);
            txt.SetPixel(0, 0, snakeColor);
            txt.Apply();
            txt.filterMode = FilterMode.Point;
            Rect rect = new Rect(0, 0, 1, 1);
            return Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect);

        }
    }
}
