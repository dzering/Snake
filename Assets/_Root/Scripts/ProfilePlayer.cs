﻿using SnakeGame.Map;

namespace SnakeGame
{
    public class ProfilePlayer
    {
        private SnakeModel snake;
        private GameState gameState;
        public float Speed = 0.2f;
        public MapModel MapModel { get; }

        public ProfilePlayer()
        {
            MapModel = new MapModel(15, 15);
        }
    }

    public enum GameState
    {
        None,
        Menu,
        Game
    }
}