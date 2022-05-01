using UnityEngine;

namespace SnakeGame.Abstractions
{
    public interface IMap
    {
        Vector3 GetCenterMap();
        INode GetNode(int x, int y);
    }
}