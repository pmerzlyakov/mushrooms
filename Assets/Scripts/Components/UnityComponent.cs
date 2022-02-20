using UnityEngine;

namespace Mushrooms
{
    public struct UnityComponent<T> where T : Component
    {
        public T Value;
    }
}