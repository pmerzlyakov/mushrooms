using Leopotam.EcsLite;
using UnityEngine;

namespace LegacyMushrooms
{
    public class DestroySystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            EcsFilter filter = world.Filter<DestroyRequest>().End();

            var reqs = world.GetPool<DestroyRequest>();

        }
    }
}
