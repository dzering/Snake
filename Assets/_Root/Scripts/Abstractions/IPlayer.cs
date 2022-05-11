using SnakeGame.Map;
using SnakeGame.UserControlSystem;
using SnakeGame.Snake;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

namespace SnakeGame.Abstractions
{
    public interface IPlayer
    {
        event Action<INode> OnMove;
        INode CurrentNode { get; set; }
        List<TailNodeView> Tail { get; }

        void Move(INode nextNode);
        void Eat(INode node);
        

    }
}