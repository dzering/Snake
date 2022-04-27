using UnityEngine;
using SnakeGame.Abstractions;

namespace SnakeGame.Map
{
    public class Node : INode
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector3 WorldPosition { get; set; }
        public Node(int x, int y)
        {
            X = x;
            Y = y;
            Vector3 vec = Vector3.zero;
            vec.x = X;
            vec.y = Y;
            vec.z = 0;
            WorldPosition = vec;
        }
    }
}
