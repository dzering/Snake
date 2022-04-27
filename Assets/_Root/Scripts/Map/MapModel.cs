using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame.Map
{
    public class MapModel
    {
        public Node[,] Grid { get; private set; }
        public List<Node> avaliableNodes;

        public MapModel(int x, int y)
        {
            CreateGrid(x, y);
        }

        private void CreateGrid(int x, int y)
        {
            Grid = new Node[x, y];
            avaliableNodes = new List<Node>();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Grid[i, j] = new Node(i, j);
                    avaliableNodes.Add(Grid[i, j]);
                }
            }
        }

    }
}