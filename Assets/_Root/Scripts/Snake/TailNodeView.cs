using SnakeGame.Base;
using SnakeGame.Map;
using UnityEngine;

namespace SnakeGame.Snake
{
    public class TailNodeView : BaseView
    {
        public Node Node { get; set; }
        public TailNodeView()
        {
            CreateView(Color.gray);
        }

    }
}
