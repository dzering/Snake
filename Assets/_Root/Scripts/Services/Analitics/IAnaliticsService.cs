using System.Collections.Generic;


namespace SnakeGame.Services.Analitics
{
    internal interface IAnaliticsService
    {
        void SendEvent(string eventName);
        void SendEvent(string eventName, Dictionary<string, object> eventData);
    }
}
