using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Map;
using SnakeGame.Snake;
using System;

namespace SnakeGame
{
    internal class Root : MonoBehaviour
    {

        private MapController mapController;
        private SnakeController snakeController;

        Node startPosition;

        void Start()
        {
            mapController = new MapController();
            startPosition = mapController.GetNode(2, 2); //TODO make random start position
            snakeController = new SnakeController();
            snakeController.snakeObj.transform.position = startPosition.worldPosition;

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}