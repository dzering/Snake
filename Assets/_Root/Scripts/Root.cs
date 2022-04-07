using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Map;
using SnakeGame.Snake;

namespace SnakeGame
{
    internal class Root : MonoBehaviour
    {

        // Start is called before the first frame update
        void Start()
        {
            new MapController();
            new SnakeController();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}