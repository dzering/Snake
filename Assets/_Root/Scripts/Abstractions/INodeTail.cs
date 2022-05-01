using UnityEngine;

namespace SnakeGame.Abstractions
{
    public interface INodeTail
    {
        public INode Node { get; set; }
        public GameObject Obj { get; set; }

    }
}
