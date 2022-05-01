using UnityEngine;

namespace SnakeGame.Abstractions
{
    public interface IMap
    {
        Vector3 GetCenterMap();
        INode GetNode(int x, int y);

        INode GetAvaliableNode();

        void RemoveNodeFromAvaliable(INode node);
        void AddNodeToAvaliable(INode node);
    }
}