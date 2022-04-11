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
        private readonly MapModel mapModel;

        private GameObject mapObject;
        private SpriteRenderer mapRender;

        private Node[,] grid;

        public int MaxWidth { get; private set; }
        public int MaxHight { get; private set; }

        public MapController(ProfilePlayer profilePlayer)
        {
            mapModel = profilePlayer.MapModel;

            MaxWidth = mapModel.Grid.GetLength(0);
            MaxHight = mapModel.Grid.GetLength(1);

            grid = mapModel.Grid;

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

        private void CreateMap()
        {
            mapRender = mapObject.AddComponent<SpriteRenderer>();

            Texture2D txt = new Texture2D(MaxWidth, MaxHight);
            for (int x = 0; x < MaxWidth; x++)
            {
                for (int y = 0; y < MaxHight; y++)
                {
                    mapModel.FillGrid(x, y);

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

            Rect rect = new Rect(0, 0, mapModel.Grid.GetLength(0), mapModel.Grid.GetLength(1));
            Sprite sprite = Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect); // Изучить метод и его параметры
            mapRender.sprite = sprite;
        }

    }
}

