using UnityEngine;

namespace SnakeGame.Tools
{
    internal static class ResourceLoader
    {
        public static GameObject LoadPrefab(ResourcePath path)
        {
            return Resources.Load<GameObject>(path.Path);
        }

    }
}
