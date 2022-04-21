using UnityEngine;



namespace SnakeGame.Base
{
    public abstract class BaseView
    {
        public GameObject GO;

        protected GameObject CreateView(Color color)
        {
            GO = new GameObject("Fruit");
            SpriteRenderer snakeRenderer = GO.AddComponent<SpriteRenderer>();
            snakeRenderer.sprite = CreateSprite(color);
            snakeRenderer.sortingOrder = 1;

            return GO;
        }

        private Sprite CreateSprite(Color color)
        {
            Texture2D txt = new Texture2D(1, 1);
            txt.SetPixel(0, 0, color);
            txt.Apply();
            txt.filterMode = FilterMode.Point;
            Rect rect = new Rect(0, 0, 1, 1);
            return Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect);
        }
    }
}