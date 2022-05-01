using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Abstractions;
using SnakeGame.Base;
using SnakeGame.Content.Fruits;

public class Spawner : BaseController
{
    
    public IFruit CreateFruit(EnumFruits enumFruits)
    {
        switch (enumFruits)
        {
            case EnumFruits.Apple:
                IFruit apple = new FruitController(default);

                return apple;
            case EnumFruits.Pear:
                IFruit pear = new FruitController(default);

                return pear;
        }
        return null;
    }
}
