using SnakeGame.Base;
using SnakeGame.Abstractions;
using UnityEngine;
using SnakeGame.Utility;

namespace SnakeGame.Snake
{
    public class TailNodeView : BaseView, INodeTail
    {
        public INode Node { get; set; }
        public TailNodeView()
        {
            Obj = CreateView(Color.gray);
            Obj.transform.localScale = Vector3.one * 0.9f;
        }

    }
}
