using UnityEngine;

namespace SnakeGame.Utility
{
    public static class Utilities
    {
        public static void PlaceObjectCorrect(GameObject obj, Vector3 pos)
        {
            pos += Vector3.one * 0.5f;
            obj.transform.position = pos;
        }
    }
}
