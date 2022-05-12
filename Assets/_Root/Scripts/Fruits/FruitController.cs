using UnityEngine;
using SnakeGame.Base;
using SnakeGame.Abstractions;

namespace SnakeGame.Content.Fruits
{
    public class FruitController : BaseController, IFruit
    {
        public readonly GameObject go; //todo change to private
        private readonly FruitView view;
        private readonly FruitModel fruitModel;

        public INode CurrentNode
        {
            get
            {
                return fruitModel.Node;
            }
            set
            {
                fruitModel.Node= value;
            }
        }

        public FruitController(INode node)
        {
            fruitModel = new FruitModel();
            view = new FruitView();
            go = view.Obj;
            AddGameObject(go);

            fruitModel.OnUpdate += view.UpdatePosition;
            fruitModel.Node = node;
        }
    }
}