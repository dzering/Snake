using UnityEngine;

namespace SnakeGame.Snake
{
    class SnakeController
    {
        private Color snakeColor;
        public GameObject snakeObj;

        public SnakeController()
        {
            snakeColor = Color.black;
            CreateSnake();
        }

        private void CreateSnake()
        {
            snakeObj = new GameObject("Player");
            SpriteRenderer snakeRenderer = snakeObj.AddComponent<SpriteRenderer>();
            snakeRenderer.sprite = CreateSprite(snakeColor);
            snakeRenderer.sortingOrder = 1;
        }

        private Sprite CreateSprite(Color targetColor)
        {
            Texture2D txt = new Texture2D(1,1);
            txt.SetPixel(0, 0, targetColor);
            txt.Apply();
            txt.filterMode = FilterMode.Point;
            Rect rect = new Rect(0, 0, 1, 1);
            return Sprite.Create(txt, rect, Vector2.one * 0.5f, 1, 0, SpriteMeshType.FullRect);

        }
    }
}
