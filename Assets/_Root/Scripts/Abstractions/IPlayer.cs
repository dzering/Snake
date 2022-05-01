using SnakeGame.Map;
using SnakeGame.UserControlSystem;


namespace SnakeGame.Abstractions
{
    public interface IPlayer
    {
        INode CurrentNode { get; set; }
        void Move(INode nextNode);
        void Eat(INode node);

    }
}