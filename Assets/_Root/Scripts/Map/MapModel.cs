using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame.Map
{
    public class MapModel
    {
        public Node[,] Grid { get; private set; }

        public MapModel(int x, int y)
        {
            Grid = new Node[x, y];
        }

        public void FillGrid(int x, int y)
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

            Grid[x, y] = node;
        }
    }
}