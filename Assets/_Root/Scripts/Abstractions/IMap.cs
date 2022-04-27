

namespace SnakeGame.Abstractions
{
    public interface IMap
    {
        INode GetNode(int x, int y);
    }
}