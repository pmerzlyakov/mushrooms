using UnityEngine;

namespace LegacyMushrooms
{
    public struct UnityComponent<T> where T : Component
    {
        public T Value;
    }
}