using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame.Map
{
    public class MapModel
    {
        public Node[,] Grid { get; private set; }
        private List<Node> avaliableNodes;

        public MapModel(int x, int y)
        {
            Grid = new Node[x, y];
            avaliableNodes = new List<Node>();
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
            avaliableNodes.Add(node);
        }

        public Node GetAvaliableNode()
        {
            int num = Random.Range(0, avaliableNodes.Count);
            Node n = avaliableNodes[num];
            return n;
        }

        public void RemoveNode(Node node)
        {
            avaliableNodes.Remove(node);
        }

        public void AddNodeToAvaliable(Node node)
        {
            avaliableNodes.Add(node);
        }

        public Node GetNode(int x, int y)
        {
            if (x < 0 || x > Grid.GetLength(0) - 1 || y < 0 || y > Grid.GetLength(1) - 1)
                return null;

            return Grid[x, y];
        }
    }
}