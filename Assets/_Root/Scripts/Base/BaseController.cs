using System.Collections.Generic;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SnakeGame.Base
{
    public abstract class BaseController : IDisposable
    {
        private List<BaseController> controllers;
        private List<GameObject> views;
        private bool isDisposed;

        public BaseController()
        {
            controllers = new List<BaseController>();
            views = new List<GameObject>();
            isDisposed = false;
        }

        public void Dispose()
        {
            if (isDisposed)
                return;

            isDisposed = true;
            OnDispose();

            foreach (var controller in controllers)
            {
                controller.OnDispose();
            }

            controllers.Clear();

            foreach (var view in views)
            {
                Object.Destroy(view);
            }

            views.Clear();
        }

        protected virtual void OnDispose() { }
        

        protected void AddController(BaseController controller)
        {
            controllers.Add(controller);
        }

        protected void AddGameObject(GameObject gameObject)
        {
            views.Add(gameObject);
        }

    }
}
