using SnakeGame.Base;
using SnakeGame.Abstractions;
using UnityEngine;

namespace SnakeGame.Snake
{
    public class TailNodeView : BaseView, INodeTail
    {
        public INode Node { get; set; }
        public TailNodeView()
        {
            Obj = CreateView(Color.gray);
        }

    }
}
