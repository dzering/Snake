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
        public readonly int MaxWidth;
        public readonly int MaxHight;

        private GameObject mapObject;

        public MapController(ProfilePlayer profilePlayer)
        {
            mapModel = profilePlayer.MapModel;
            MaxWidth = mapModel.Grid.GetLength(0);
            MaxHight = mapModel.Grid.GetLength(1);

            mapView = LoadView();
            AddGameObject(mapObject);
            CreateMap();
        }
        public void RemoveNode(Node node)
        {
            mapModel.avaliableNodes.Remove(node);
        }

        public void AddNodeToAvaliable(Node node)
        {
            mapModel.avaliableNodes.Add(node);
        }

        public Node GetAvaliableNode()
        {
            int num = Random.Range(0, mapModel.avaliableNodes.Count);
            Node n = mapModel.avaliableNodes[num];
            return n;
        }

        public Node GetNode(int x, int y)
        {
            if (x < 0 || x > MaxWidth - 1 || y < 0 || y > MaxHight - 1)
                return null;

            return mapModel.Grid[x,y];
        }

        private MapView LoadView()
        {
            var pref = ResourceLoader.LoadPrefab(path);
            mapObject = GameObject.Instantiate(pref);
            return mapObject.GetComponent<MapView>();
        }

        private void CreateMap()
        {
            SpriteRenderer mapRender = mapObject.AddComponent<SpriteRenderer>();

            Texture2D txt = new Texture2D(MaxWidth, MaxHight);
            for (int x = 0; x < MaxWidth; x++)
            {
                for (int y = 0; y < MaxHight; y++)
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
            
            txt.filterMode = FilterMode.Point;
            txt.Apply();

            Rect rect = new Rect(0, 0, MaxWidth, MaxHight);
            Sprite sprite = Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect); // ������� ����� � ��� ���������
            mapRender.sprite = sprite;
        }

    }
}

