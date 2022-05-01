using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Content.Fruits;
using SnakeGame.Base;

namespace SnakeGame.Abstractions
{
    public interface IFruit
    {
       // void SetPosition(INode node);
        INode CurrentNode { get; set; }
    }
}