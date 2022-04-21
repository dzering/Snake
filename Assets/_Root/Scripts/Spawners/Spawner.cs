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
                IFruit apple = new FruitController();

                return apple;
            case EnumFruits.Pear:
                IFruit pear = new FruitController();

                return pear;
        }
        return null;
    }
}
