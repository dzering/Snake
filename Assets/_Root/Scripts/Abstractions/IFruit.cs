using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SnakeGame.Content.Fruits;
using SnakeGame.Base;

namespace SnakeGame.Abstractions
{
    public interface IFruit
    {
        INode CurrentNode { get; set; }
        void SetPosition(INode node);
    }
}