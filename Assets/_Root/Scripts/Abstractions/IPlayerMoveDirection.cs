using SnakeGame.Map;
using SnakeGame.UserControlSystem;


namespace SnakeGame.Abstractions
{
    public interface IPlayerMoveDirection
    {

        Direction CurrentDirection { get; set; }

    }
}