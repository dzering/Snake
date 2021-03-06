using Object = UnityEngine.Object;
using UnityEngine;
using SnakeGame.Tools.ResourceManager;
using SnakeGame.Base;
using SnakeGame.Abstractions;
using SnakeGame.Profile;

using SnakeGame.Content.Fruits;
using System.Collections.Generic;

namespace SnakeGame.Map
{
    public class MapController : BaseController, IMap
    {
        private readonly ResourcePath path = new ResourcePath() { Path = "Prefabs/Map" };

        private readonly MapView viewMap;
        private readonly MapModel modelMap;
        private GameObject ObjMap;

        public readonly int MaxWidth;
        public readonly int MaxHight;

        private List<FruitController> listAvaliableMarkers; // Delete


        public MapController(ProfilePlayer profilePlayer)
        {
            modelMap = profilePlayer.MapModel;
            MaxWidth = modelMap.Grid.GetLength(0);
            MaxHight = modelMap.Grid.GetLength(1);

            viewMap = LoadView();
            AddGameObject(ObjMap);
            CreateMap();


            TestAvaliable(); // TestAvaliable Delete
        }

        #region TestAvaliable
        private void TestAvaliable()
        {
            listAvaliableMarkers = new List<FruitController>();
            foreach (var item in modelMap.avaliableNodes)
            {
                FruitController marker = new FruitController(item);
                Vector3 newPosition = item.WorldPosition;
                newPosition.x -= 10f;
                Utility.Utilities.PlaceObjectCorrect(marker.go, newPosition);
                listAvaliableMarkers.Add(marker);
            }
        }

        private void RemoveMarkers(INode node)
        {
                for (int i = 0; i < listAvaliableMarkers.Count; i++)
                {
                    if(listAvaliableMarkers[i].CurrentNode == node)
                    {
                        listAvaliableMarkers[i].go.SetActive(false);
                    }
                }
        }

        private void AddMarkers(INode node)
        {
            for (int i = 0; i < listAvaliableMarkers.Count; i++)
            {
                if (listAvaliableMarkers[i].CurrentNode == node)
                {
                    listAvaliableMarkers[i].go.SetActive(true);
                }
            }

        }

        #endregion

        public void RemoveNodeFromAvaliable(INode node)
        {
            modelMap.avaliableNodes?.Remove(node);
            RemoveMarkers(node); // Delete
        }

        public void AddNodeToAvaliable(INode node)
        {
            modelMap.avaliableNodes?.Add(node);
            AddMarkers(node); // Delete
        }

        public INode GetAvaliableNode()
        {
            int num = Random.Range(0, modelMap.avaliableNodes.Count);
            INode n = modelMap.avaliableNodes[num];
            return n;
        }

        public INode GetNode(int x, int y)
        {
            if (x < 0 || x > MaxWidth - 1 || y < 0 || y > MaxHight - 1)
                return null;

            return modelMap.Grid[x,y];
        }

        public Vector3 GetCenterMap()
        {
            Vector3 vec = ObjMap.GetComponent<SpriteRenderer>().sprite.rect.center;
            Vector3 sideOne = modelMap.Grid[0, 0].WorldPosition;
            Vector3 sideTwo = modelMap.Grid[MaxWidth-1, MaxHight-1].WorldPosition;

            return vec;//(sideTwo - sideOne)/2;
        }
        private MapView LoadView()
        {
            var pref = ResourceLoader.LoadPrefab(path);
            ObjMap = GameObject.Instantiate(pref);
            return ObjMap.GetComponent<MapView>();
        }

        private void CreateMap()
        {
            SpriteRenderer mapRender = ObjMap.AddComponent<SpriteRenderer>();

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
                            txt.SetPixel(x, y, viewMap.Color1);
                        }
                        else
                        {
                            txt.SetPixel(x, y, viewMap.Color2);
                        }
                    }
                    else
                    {
                        if (y % 2 != 0)
                        {
                            txt.SetPixel(x, y, viewMap.Color2);
                        }
                        else
                        {
                            txt.SetPixel(x, y, viewMap.Color1);
                        }

                    }
                    #endregion
                }
            }
            
            txt.filterMode = FilterMode.Point;
            txt.Apply();

            Rect rect = new Rect(0, 0, MaxWidth, MaxHight);
            Sprite sprite = Sprite.Create(txt, rect, Vector2.zero, 1, 0, SpriteMeshType.FullRect);
            mapRender.sprite = sprite;
        }
    }
}

