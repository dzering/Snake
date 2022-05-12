using SnakeGame.Map;
using SnakeGame.Tools.Reactive;

namespace SnakeGame.Profile
{
    public class ProfilePlayer
    {
        public SubscriptionProperty<GameState> CurrentState { get; }
        public MapModel MapModel { get; }
        public float Speed = 0.2f;
        
        private SnakeModel snake;

        public ProfilePlayer()
        {
            MapModel = new MapModel(8, 8);
        }
    }

}