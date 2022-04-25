﻿using SnakeGame.Map;

namespace SnakeGame
{
    public class ProfilePlayer
    {
        private SnakeModel snake;
        private GameState gameState;
        public MapModel MapModel { get; }

        public ProfilePlayer()
        {
            MapModel = new MapModel(8, 8);
        }
    }

    public enum GameState
    {
        None,
        Menu,
        Game
    }
}