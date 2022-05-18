using System.Collections.Generic;

namespace SnakeGame.Services.Analitics.UnityAnalitics
{
    internal class UnityAnaliticsService : IAnaliticsService
    {
        public void SendEvent(string eventName)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(eventName);
            UnityEngine.Debug.Log($"Unity Analitics event Sended - {eventName}");
        }
        public void SendEvent(string eventName, Dictionary<string, object> eventData)
        {
            UnityEngine.Analytics.Analytics.CustomEvent(eventName, eventData);
        }

    }
}