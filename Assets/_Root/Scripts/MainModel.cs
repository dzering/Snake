

namespace SnakeGame
{
    public class MainModel
    {
        private SnakeModel snake;
        private GameState gameState;
    }

    public enum GameState
    {
        None,
        Menu,
        Game
    }
}