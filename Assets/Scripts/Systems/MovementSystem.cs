using Leopotam.EcsLite;
using UnityEngine;

namespace Mushrooms
{
    public class MovementSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();

            var movements = world.GetPool<MovementComponent>();
            var rbodies = world.GetPool<UnityComponent<Rigidbody>>();

            var mask = world.Filter<MovementComponent>();
            mask.Inc<UnityComponent<Rigidbody>>();
            EcsFilter filter = mask.End();

            foreach (int entity in filter)
            {
                ref var mvmt = ref movements.Get(entity);
                ref var rbody = ref rbodies.Get(entity);

                Rigidbody rb = rbody.Value;
                var pos = Vector3.MoveTowards(rb.position, mvmt.Target, mvmt.Speed * Time.fixedDeltaTime);

                rb.MovePosition(pos);
            }
        }
    }
}
