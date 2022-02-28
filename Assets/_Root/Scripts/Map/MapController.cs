using Object = UnityEngine.Object;
using UnityEngine;
using Snake3D.Tools;

namespace Snake3D.Map
{

    internal class MapController : BaseController
    {
        private ResourcePath path = new ResourcePath() { Path = "Map" };
        private readonly MapView mapView;

        private GameObject mapObject;
        private SpriteRenderer mapRender;

        public MapController()
        {
            mapView = LoadView();
            AddGameObject(mapObject);
        }

        private MapView LoadView()
        {
            var pref = ResourceLoader.LoadPrefab(path);
            mapObject = Object.Instantiate(pref);
            return mapObject.GetComponent<MapView>();
        }

        private void CreateMap()
        {
            mapObject = new GameObject("Map");
            mapRender = mapObject.AddComponent<SpriteRenderer>();

            Texture2D txt = new Texture2D(mapView.MaxWidth, mapView.MaxHight);
            for (int x = 0; x < mapView.MaxWidth; x++)
            {
                for (int y = 0; y < mapView.MaxHight; y++)
                {
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

            txt.Apply();

            Rect rect = new Rect(0, 0, mapView.MaxWidth, mapView.MaxHight);
            Sprite sprite = Sprite.Create(txt, rect, Vector2.one * 0.5f, 1, 0, SpriteMeshType.FullRect); // ������� ����� � ��� ���������
            mapRender.sprite = sprite;
        }

    }
}

