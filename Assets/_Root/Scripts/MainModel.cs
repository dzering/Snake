

namespace SnakeGame
{
    internal class MainModel
    {
        private SnakeModel snake;
        private GameState gameState;
    }

    internal enum GameState
    {
        None,
        Menu,
        Game
    }
}