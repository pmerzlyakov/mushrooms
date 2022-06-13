using UnityEngine;

namespace Mushrooms
{
    public struct UComponent<T> where T : Component
    {
        public T Value;
    }
}
