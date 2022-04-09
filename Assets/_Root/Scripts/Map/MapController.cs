using Object = UnityEngine.Object;
using UnityEngine;
using SnakeGame.Tools.ResourceManager;
using SnakeGame.Base;

namespace SnakeGame.Map
{
    public class MapController : BaseController
    {
        private readonly ResourcePath path = new ResourcePath() { Path = "Prefabs/Map" };
        private readonly MapView mapView;

        private GameObject mapObject;
        private SpriteRenderer mapRender;

        private Node[,] grid;

        public int MaxWidth { get; private set; }
        public int MaxHight { get; private set; }

        public MapController()
        {
            mapView = LoadView();
            AddGameObject(mapObject);
            CreateMap();
        }

        private MapView LoadView()
        {
            var pref = ResourceLoader.LoadPrefab(path);
            mapObject = GameObject.Instantiate(pref);
            return mapObject.GetComponent<MapView>();
        }

        public Node GetNode(int x, int y)
        {
            if (x < 0 || x > mapView.MaxWidth - 1 ||  y < 0 || y > mapView.MaxHight - 1)
                return null;

            return grid[x, y];
        }

        private void CreateMap()
        {
            mapRender = mapObject.AddComponent<SpriteRenderer>();
            MaxWidth = mapView.MaxWidth;
            MaxHight = mapView.MaxHight;
            grid = new Node[MaxWidth, MaxHight];

            Texture2D txt = new Texture2D(MaxWidth, MaxHight);
            for (int x = 0; x < MaxWidth; x++)
            {
                for (int y = 0; y < MaxHight; y++)
                {
                    Vector3 targetPosition = Vector3.zero;
                    targetPosition.x = x;
                    targetPosition.y = y;

                    Node node = new Node()
                    {
                        X = x,
                        Y = y,
                        worldPosition = targetPosition
                    };

                    grid[x, y] = node;

                    #region Visual
                    if (x % 2 != 0)
                    {
                        if (y % 2 != 0)
                        {
                            txt.SetPixel(x, y, mapView.Color1);
                        }
                        else
                        {
                            txt.SetPixel(x, y, mapView.Color2);
                        }
                    }
                    else
                    {
                        if (y % 2 != 0)
                        {
                            txt.SetPixel(x, y, mapView.Color2);
                        }
                        else
                        {
                            txt.SetPixel(x, y, mapView.Color1);
                        }

                    }
                    #endregion

                }

            }

            txt.filterMode = FilterMode.Point;

            txt.Apply();

            Rect rect = new Rect(0, 0, mapView.MaxWidth, mapView.MaxHight);
            Sprite sprite = Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect); // Изучить метод и его параметры
            mapRender.sprite = sprite;
        }

    }
}

