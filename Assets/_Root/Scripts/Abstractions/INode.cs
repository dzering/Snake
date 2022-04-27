using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeGame.Abstractions
{
    public interface INode
    {
        int X { get; set; }
        int Y { get; set; }

        Vector3 WorldPosition { get; set; }
    }
}