using UnityEngine;

namespace Mushrooms.Extensions.Ecs
{
    public static class UnityComponent
    {
        public static EntityProvider GetProvider(this Component component)
        {
            var go = component.gameObject;

            var providerExist = go.TryGetComponent(out EntityProvider provider);
            if (!providerExist)
            {
                provider = go.AddComponent<EntityProvider>();
            }

            return provider;
        }

        public static bool HasProvider(this Component component)
        {
            var go = component.gameObject;
            return go.TryGetComponent<EntityProvider>(out _);
        }
    }
}
