using System;
using UnityEngine;

namespace SnakeGame.Services.Analitics
{
    internal class AnaliticsManager : MonoBehaviour
    {
        private IAnaliticsService[] services;

        private void Awake()
        {
            services = new IAnaliticsService[]
            {
                new UnityAnalitics.UnityAnaliticsService()
            };
        }

        public void GameLaunched()
        {
            SendEvent("GameLaunched");
        }

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < services.Length; i++)
            {
                services[i].SendEvent(eventName);

            }
        }
    }
}
